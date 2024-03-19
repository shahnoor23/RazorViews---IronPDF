namespace Items_Report.Models;

public class ItemCategory
{
    public string itemCategoryKey { get; set; }
    public string categoryName { get; set; }
    public int sequence { get; set; }
    public List<OrderItemList> orderItemList { get; set; }
}

public class OrderItemDetailsList
{
    public string itemOption { get; set; }
    public int quantity { get; set; }
    public List<string> orderIds { get; set; }
}

public class OrderItemList
{
    public string itemName { get; set; }
    public int quantity { get; set; }
    public bool isContinued { get; set; }
    public List<OrderItemDetailsList> orderItemDetailsList { get; set; }
}

public class Root
{
    public string supplierName { get; set; }
    public string summary { get; set; }
    public List<ItemCategory> itemCategories { get; set; }
}