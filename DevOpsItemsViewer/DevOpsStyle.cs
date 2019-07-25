namespace DevOpsItemsViewer
{
    public static class DevOpsStyle
    {
        public static string GetBorderColorByItemType(string itemType) {
            switch (itemType)
            {
                case "Epic":
                    return "#ff7b00";
                case "Feature":
                    return "#773b93";
                case "Product Backlog Item":
                    return "#009ccc";
                case "Bug":
                    return "red";
                default:
                    return "";

            }
        }
    }
}
