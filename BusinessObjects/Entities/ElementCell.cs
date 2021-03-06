using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace forCrowd.Backbone.BusinessObjects.Entities
{
    public class ElementCell : BaseEntity
    {
        public ElementCell()
        {
            UserElementCellSet = new HashSet<UserElementCell>();
        }

        public int Id { get; set; }

        [Index("UX_ElementCell_ElementFieldId_ElementItemId", 1, IsUnique = true)]
        public int ElementFieldId { get; set; }

        [Index("UX_ElementCell_ElementFieldId_ElementItemId", 2, IsUnique = true)]
        public int ElementItemId { get; set; }

        public string StringValue { get => stringValue; set => stringValue = value?.Trim(); }

        public decimal DecimalValueTotal { get; set; }
        public int DecimalValueCount { get; set; }

        /// <summary>
        /// In case this cell's field type is Element, this is the selected item for this cell.
        /// Other values are stored on UserElementCell, but since this one has FK, it's directly set on ElementCell.
        /// </summary>
        public int? SelectedElementItemId { get; set; }
        public ElementItem ElementItem { get; set; }
        public ElementField ElementField { get; set; }
        public ElementItem SelectedElementItem { get; set; }
        public ICollection<UserElementCell> UserElementCellSet { get; set; }
        public UserElementCell UserElementCell => UserElementCellSet.SingleOrDefault();

        string stringValue;
    }
}
