using Pure.BO.Core;
using Pure.BO.Spaces.Attributes;
using Pure.BO.Spaces.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pure.BO.Spaces
{
    public class Space : Core.Core
    {
        #region Constructors
        public Space() => SetDefaultKey();
        public Space(string name) : this() => Name = name;
        public Space(string name, string description) : this(name) => Description = description;
        #endregion

        #region Properties
        public Space? this[int index]
        {
            get { return Spaces[index]; }
        }
        /// <summary>
        /// The name of the space
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must supply a name")]
        public string? Name { get; set; }
        /// <summary>
        /// The type of the space
        /// </summary>
        public string? Type { get; private set; }
        /// <summary>
        /// A description adding context
        /// </summary>
        public string? Description { get; set; }
        [JsonIgnore]
        /// <summary>
        /// The parent of this <see cref="Space"/>
        /// </summary>
        public Space? Parent { get; private set; }
        private string? _parentId;
        public string? ParentId
        {
            get => _parentId;
            set => _parentId = value;
        }
        private List<Space> _spaces = [];
        /// <summary>
        /// Read only collection of <see cref="Space"/> objects within this space
        /// </summary>
        [JsonIgnore()]
        public ReadOnlyCollection<Space> Spaces => _spaces.AsReadOnly();
        private Dictionary<string, string>? _attributes;
        /// <summary>
        /// A collection of attributes about the space
        /// </summary>
        public Dictionary<string, string> Attributes
        {
            get => _attributes ?? [];
            set => _attributes = value;
        }
        /// <summary>
        /// Switch specifying if the <see cref="SpaceAttribute"/> is inside or outside
        /// </summary>
        public bool Inside { get; set; } = false;
        private List<CalendarItem>? _calendar;
        /// <summary>
        /// A Calendar regarding the <see cref="Space"/>
        /// </summary>
        public List<CalendarItem> Calendar
        {
            get
            {
                _calendar ??= [];
                return _calendar;
            }
            set { _calendar = value; }
        }
        private Note? _note;
        public Note Note
        {
            get
            {
                if (_note == null) { _note = new(); }
                return _note;
            }
            set { _note = value; }
        }
        #endregion

        #region Helpers
        public void SetType(SpaceTypes spaceType) => Type = Enum.GetName(typeof(SpaceTypes), spaceType)!.Replace("_", "")!;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public void SetType(string type) => Type = type;
        /// <summary>
        /// Adds the passed <see cref="Space"/> to the <see cref="Spaces"/> collection setting this as parent
        /// </summary>
        /// <param name="space">A <see cref="Space"/> instance</param>
        /// <returns>The passed <see cref="Space"/></returns>
        public Space AddSpace(Space space)
        {
            space.Parent = this;
            space.ParentId = RowKey;
            _spaces.Add(space);

            return space;
        }
        /// <summary>
        /// Adds the passed <see cref="Space"/> collection to this <see cref="Spaces"/> collection
        /// </summary>
        /// <param name="spaces">A collection of <see cref="Space"/> objects</param>
        /// <returns>The passed list</returns>
        public List<Space> AddSpaces(List<Space> spaces) => spaces.Select(AddSpace).ToList();
        /// <summary>
        /// Adds the passed <see cref="Space"/> collection to this <see cref="Spaces"/> collection
        /// </summary>
        /// <param name="spaces">A collection of <see cref="Space"/> objects</param>
        /// <returns>The passed array</returns>
        public Space[] AddSpaces(Space[] spaces) => spaces.Select(AddSpace).ToArray();
        /// <summary>
        /// Adds the passed <see cref="Space"/> collection to this <see cref="Spaces"/> collection
        /// </summary>
        /// <param name="spaces">A collection of <see cref="Space"/> objects</param>
        /// <returns>The passed <see cref="IEnumerable{T}"/></returns>
        public IEnumerable<Space> AddSpaces(IEnumerable<Space> spaces) => spaces.Select(AddSpace).ToArray();
        /// <summary>
        /// Removes the passed <see cref="TreeNode{T}"/>
        /// </summary>
        /// <param name="node">The <see cref="TreeNode{T}"/> to be removed</param>
        /// <returns>True if the node has been removed</returns>
        public bool RemoveSpace(Space space) => _spaces.Remove(space);
        /// <summary>
        /// Crawls the <see cref="Space"/> collection performing the <see cref="Action{T}"/> passed
        /// </summary>
        /// <param name="action">An <see cref="Action{T}"/></param>
        public void DoAction(Action<Space> action)
        {
            action(this);

            for (int i = 0; i < Spaces.Count; i++)
            {
                Spaces[i].DoAction(action);
            }
        }
        /// <summary>
        /// Finds the <see cref="Space"/> matching the <see cref="Func{T, TResult}"/> passed
        /// </summary>
        /// <param name="function">A <see cref="Func{T, TResult}"/> containing your find logic</param>
        /// <returns>Returns the first <see cref="Space"/> matching the passed condition or null if not found</returns>
        public Space? Find(Func<Space, bool> function)
        {
            if (function(this))
            {
                return this;
            }
            return Flatten().FirstOrDefault(function);
        }
        /// <summary>
        /// Finds all <see cref="Space"/> objects matching the passed condition
        /// </summary>
        /// <param name="function"></param>
        /// <returns>All matching <see cref="Space"/> objects</returns>
        public List<Space>? FindAll(Func<Space, bool> function) => Flatten().Where(function).ToList();
        /// <summary>
        /// Flattens this <see cref="Space"/> and it's child <see cref="Space"/> collection into an <see cref="Array"/> of <see cref="Space"/> objects
        /// </summary>
        /// <returns>An Array of T</returns>
        public IEnumerable<Space> Flatten() => new[] { this }.Concat(Spaces.SelectMany(s => s.Flatten()));
        /// <summary>
        /// Re-establishes the hierarchy of all child spaces
        /// </summary>
        /// <remarks>
        /// Will only be run on a <see cref="Space"/>with no <see cref="Parent"/>
        /// </remarks>
        public void RebuildHierarchy()
        {
            if (Parent == null)
            {
                int i = 0;
                int size = Spaces.Count;

                while (i < size)
                {
                    Space space = Spaces[i];

                    space.RebuildHierarchy(this);

                    i++;
                }
            }
        }
        protected void RebuildHierarchy(Space parent)
        {
            Parent = parent;

            int i = 0;
            int size = Spaces.Count;

            while (i < size)
            {
                Space space = Spaces[i];

                space.RebuildHierarchy(Parent);

                i++;
            }
        }
        /// <summary>
        /// Creates an all day <see cref="CalendarItem"/> with the details specified
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/></param>
        /// <param name="description">A short description</param>
        /// <param name="note">Optional - A note regarding the <see cref="CalendarItem"/></param>
        public void CreateAllDayCalendarItem(DateTime dateTime, string title, string? description = null)
        {
            CalendarItem calendarItem = new(dateTime);
            calendarItem.MakeAllDay();
            calendarItem.Title = title;
            calendarItem.Description = description;
            Calendar.Add(calendarItem);
        }
        public int GetSpacesDepth() => GetSpacesDepth(this);
        private int GetSpacesDepth(Space space)
        {
            if (space.Spaces.Count == 0)
            {
                return 0;
            }

            int maxDepth = 0;

            int size = space.Spaces.Count;
            int i = 0;

            while (i < size)
            {
                Space item = space.Spaces[i];
                int childDepth = GetSpacesDepth(item);
                if (childDepth > maxDepth)
                {
                    maxDepth = childDepth;
                }
                i++;
            }
            return maxDepth + 1;
        }
        /// <summary>
        /// Converts the <see cref="Space"/> into a Json string
        /// </summary>
        /// <returns>A Json string</returns>
        public string ToJson()
        {
            // Get the depth of all spaces
            int depth = GetSpacesDepth() + 1;
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                WriteIndented = true,
                Converters = { new SpaceJsonConverter() }
            };
            return JsonSerializer.Serialize(this, jsonSerializerOptions);
        }
        public void FromJson(string json)
        {
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                WriteIndented = true,
                Converters = { new SpaceJsonConverter() }
            };

            Space? space = JsonSerializer.Deserialize<Space>(json, jsonSerializerOptions);
        }
        public void RebuildHierarchy(IEnumerable<Space> spaces)
        {
            // Get all spaces that have this as a parent
            List<Space>? children = spaces.Where(f => f.ParentId == RowKey).ToList();

            if (children != null)
            {
                int i = 0;
                int size = Spaces.Count;

                AddSpaces(children);

                while (i < size)
                {
                    Space space = children[i];

                    Spaces[i].RebuildHierarchy(spaces);
                    i++;
                }
            }

        }
        public override void SetDefaultKey()
        {
            base.SetDefaultKey();
            PartitionKey = "Space";
        }
        #endregion
    }
}
