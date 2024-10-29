public class Report
{
    public enum ReportCategory //ändrade från 'type' till 'category'
    {
        TotalSales,
        WeeklySales,
        DailySales,
        PrintReceipt
    }

     public int ReportNumber {get; set;}
     public DateTime Date {get; set;}
     public ReportCategory Category {get; set;} // Ändrade från 'type' till 'Category'

     public List<Sales> Sales {get; set;} = new(); 

     public void AddSale(Product product, int quantity, DateTime date)
     {
         Sales.Add(new Sales(product, quantity, date));
     }
}


 public class Sales // för att hantera individuella 'sales' inom 'Report'-rapporter.
                    //TODO gör en egen flik för Sales-klassen?
                    //TODO länka Sales och produkt-lista
 {
     public decimal TotalAmount => (decimal)Quantity * (decimal)Product.Price; //kalkylerar total försäljning av 'Product'
     public Product Product {get; set;} //TODO länka Sales till Product som säljs
     public DateTime Date {get; set;} //TODO kanske fler egenskaper än summa + tid/datum?
//   public int SalesId {get; set;} //?? ett sätt att identifiera varje unik 'sale' tillfälle, dvs varje 'Table'

     public int Quantity {get; set;} // 'samlar' antal unika sales-tillfällen


     public Sales(Product product, int quantity, DateTime date)
     {
         Product = product;
         Quantity = quantity;
         Date = date;
     }
 }


public static class ReportHandler
{
    public static List<Report> SalesList {get; set;}  =  new(); 

    public static decimal ReportGenerator(Report.ReportCategory reportCategory, DateTime startDate, DateTime endDate) //generarar sales-rapporter av de slag vi vill ha
                                                                                //lade till manuell DateTime-filtrering for now baserat på user input
                                                                                //TODO integrera maunell datum-input till Table??
    {
        if (reportCategory == Report.ReportCategory.TotalSales)
        {
            return TotalSales(startDate, endDate);
        }
       /* else if (reportCategory == Report.reportCategory.WeeklySales)
        {
            return WeeklySales(startDate, endDate);
        }
        else if (reportCategory == Report.reportCategory.DailySales)
        {
            return DailySales(startDate, endDate);
        } */
        else
        {
            return 0;
        }
    }
    public static decimal TotalSales(DateTime startDate, DateTime endDate)
    {
        return SalesList.Sum(report=> report.Sales.Sum(sale => sale.TotalAmount)); //ser till att få en rapport-kategori i taget att funka
    } 
    //public static decimal WeeklySales(){}
    //public static decimal DailySales(){}
    //public static decimal PrintReport(){}
    
}
/* public static string PrintReport(Report report) {}
{
    var report = 
} */