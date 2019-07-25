namespace DevOpsItemsViewer
{
    public static class DevOpsStyle
    {
        public static string GetBorderColorByItemType(string itemType)
        {
            switch (itemType)
            {
                case "Epic":
                    return "#ff7b00";
                case "Feature":
                    return "#773b93";
                case "Product Backlog Item":
                    return "#009ccc";
                case "Task":
                    return "#f2cb1d";
                case "Bug":
                    return "red";
                default:
                    return "";

            }
        }

        public static string GetBadgeStyleByItemState(string itemState)
        {
            switch (itemState)
            {
                case "In Progress":
                    return "badge-success";
                case "In Discussion":
                case "Committed":
                    return "badge-warning";
                case "To Do":
                    return "badge-danger";
                case "Removed":
                case "Closed":
                    return "badge-light";
                default:
                    return "badge-info";
            }
        }
    }
}
