namespace Prog_Lab2_Task2
{
    internal class Task2
    {
        public static void Main(string[] args)
        {
            Shop shop = new Shop("'Зiрочка'");
            shop.AddProduct(new Product(Product.Type.Крупа,"Каша вiсяна 'Геркулес'",45,
                new DateTime(2022,3,10),new DateTime(2022,9,10)));
            shop.AddProduct(new Product(Product.Type.Солодощi,"'Шалена бджiлка'",100,
                new DateTime(2020,1,15),new DateTime(2020,11,15)));
            shop.AddProduct(new Product(Product.Type.Випiчка,"Хлiб Нiжинський",15,
                new DateTime(2022,5,26),new DateTime(2022,5,27)));
            shop.AddProduct(new Product(Product.Type.Випiчка,"Булка Здобна",20,
                new DateTime(2022,5,24),new DateTime(2022,5,25)));
            shop.SortProducts();
            shop.FindProductDiapazone(new DateTime(2022, 5, 25),new DateTime(2022,5,27));
            shop.FindEndedProducts();
            shop.FindJanuaryProducts();
        }
    }

    public class ProductComparer : IComparer<Product>
    {
        public int Compare(Product o1, Product o2)
        {
            if (o1.ProductType > o2.ProductType)
                return 1;
            if (o1.ProductType < o2.ProductType)
                return -1; 
            if (o1.Price > o2.Price)
                return -1;
            if (o1.Price < o2.Price)
                return 1;
            for (int i = 0; i < o1.Name.Length; i++)
            {
                if (o1.Name[i] > o2.Name[i] || i >= o2.Name.Length)
                    return 1;
                if (o1.Name[i] < o2.Name[i])
                    return -1;
            }
            return 0;
        }
    }

    public class Shop
    {
        public Shop(string name)
        {
            Name = name;
        }

        public string Name { set; get; }
        public ProductComparer pc = new ProductComparer(); 
        public List<Product> ShopList = new List<Product>();

        public void WriteShoplist(List<Product> list)
        {
            foreach (Product product in list)
            {
                Console.WriteLine(product.ProductType + " " + product.Name + " " + product.Price + "грн " + 
                                  product.StartDate.Day+"."+product.StartDate.Month+"."+product.StartDate.Year + " " +
                                  product.EndDate.Day+"."+product.EndDate.Month+"."+product.EndDate.Year);
            }
            Console.WriteLine();
        }

        public void FindProductDiapazone(DateTime d1, DateTime d2)
        {
            if (d2 < d1)
                (d2, d1) = (d1, d2);
            List<Product> list = new List<Product>();
            foreach (Product product in ShopList)
                if (product.EndDate >= d1 && product.EndDate <= d2)
                    list.Add(product);
            Console.WriteLine("Продукти, що мають бути вжитi з " +  d1.Day+"."+d1.Month+"."+d1.Year + " по " + 
                              d2.Day+"."+d2.Month+"."+d2.Year + ":");
            WriteShoplist(list);
        }

        public void FindEndedProducts()
        {
            List<Product> list = new List<Product>();
            foreach (Product product in ShopList)
                if(product.EndDate<DateTime.Today)
                    list.Add(product);
            Console.WriteLine("Просроченi продукти:");
            WriteShoplist(list);
        }

        public void FindJanuaryProducts()
        {
            List<Product> list = new List<Product>();
            foreach (Product product in ShopList)
                if(product.StartDate.Year == 2020 && product.StartDate.Month == 1)
                    list.Add(product);
            Console.WriteLine("Продукти виготовленi у сiчнi 2020:");
            WriteShoplist(list);
        }

        public void AddProduct(Product prod)
        {
            ShopList.Add(prod);
        }

        public void SortProducts()
        {
            ShopList.Sort(pc);
            Console.WriteLine("Список продуктiв в магазинi " + Name + ":");
            WriteShoplist(ShopList);
        }
    }

    public class Product
    {
        public enum Type
        {
            Випiчка,
            Крупа,
            Мясо,
            Овочi,
            Риба,
            Солодощi,
            Снеки,
            Фрукти
        }

        public Type ProductType { set; get; }
        public string Name { set; get; }
        public float Price { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }

        public Product(Type productType, string name, float price,DateTime startDate, DateTime endDate)
        {
            ProductType = productType;
            Name = name;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
        }

    }
        
}