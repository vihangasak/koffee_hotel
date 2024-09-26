namespace Koffee_Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catergory",
                c => new
                    {
                        CatergoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        DisplayOrder = c.Int(nullable: false),
                        Catergory2_CatergoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CatergoryID)
                .ForeignKey("dbo.Catergory", t => t.Catergory2_CatergoryID)
                .Index(t => t.Catergory2_CatergoryID);
            
            CreateTable(
                "dbo.FoodItem",
                c => new
                    {
                        FoodID = c.Int(nullable: false),
                        FoodName = c.String(nullable: false, maxLength: 150, unicode: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(nullable: false, maxLength: 350, unicode: false),
                        CatergoryID = c.Int(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        BalanceQty = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.FoodID)
                .ForeignKey("dbo.Catergory", t => t.CatergoryID)
                .Index(t => t.CatergoryID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        FoodID = c.Int(nullable: false),
                        CatergoryID = c.Int(nullable: false),
                        ProductCount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.OrderID, t.FoodID, t.CatergoryID })
                .ForeignKey("dbo.Order", t => t.OrderID)
                .ForeignKey("dbo.FoodItem", t => t.FoodID)
                .ForeignKey("dbo.Catergory", t => t.CatergoryID)
                .Index(t => t.OrderID)
                .Index(t => t.FoodID)
                .Index(t => t.CatergoryID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false, storeType: "date"),
                        StatusID = c.Int(nullable: false),
                        ReservationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Reservation", t => t.ReservationID)
                .ForeignKey("dbo.Status", t => t.StatusID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.StatusID)
                .Index(t => t.ReservationID);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false, storeType: "date"),
                        ReservationTimeFrom = c.Time(nullable: false, precision: 7),
                        ReservationTimeTo = c.Time(nullable: false, precision: 7),
                        NoGuests = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.Status", t => t.StatusID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.Parking",
                c => new
                    {
                        ParkingID = c.Int(nullable: false, identity: true),
                        ReservationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParkingID)
                .ForeignKey("dbo.Reservation", t => t.ReservationID)
                .Index(t => t.ReservationID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        StatusType = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        Gender = c.String(nullable: false, maxLength: 10, unicode: false),
                        DOB = c.DateTime(storeType: "date"),
                        Age = c.Int(),
                        Address = c.String(maxLength: 200, unicode: false),
                        ActiverUser = c.Boolean(nullable: false),
                        UserTypeID = c.Int(),
                        CreateDateTime = c.DateTime(nullable: false),
                        EmailAddress = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserType", t => t.UserTypeID)
                .Index(t => t.UserTypeID);
            
            CreateTable(
                "dbo.UserType",
                c => new
                    {
                        UserTypeID = c.Int(nullable: false),
                        UserTypeName = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.UserTypeID);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemType = c.String(nullable: false, maxLength: 50, unicode: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "CatergoryID", "dbo.Catergory");
            DropForeignKey("dbo.FoodItem", "CatergoryID", "dbo.Catergory");
            DropForeignKey("dbo.OrderDetail", "FoodID", "dbo.FoodItem");
            DropForeignKey("dbo.User", "UserTypeID", "dbo.UserType");
            DropForeignKey("dbo.Reservation", "UserID", "dbo.User");
            DropForeignKey("dbo.Order", "UserID", "dbo.User");
            DropForeignKey("dbo.Reservation", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Order", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Parking", "ReservationID", "dbo.Reservation");
            DropForeignKey("dbo.Order", "ReservationID", "dbo.Reservation");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Catergory", "Catergory2_CatergoryID", "dbo.Catergory");
            DropIndex("dbo.User", new[] { "UserTypeID" });
            DropIndex("dbo.Parking", new[] { "ReservationID" });
            DropIndex("dbo.Reservation", new[] { "StatusID" });
            DropIndex("dbo.Reservation", new[] { "UserID" });
            DropIndex("dbo.Order", new[] { "ReservationID" });
            DropIndex("dbo.Order", new[] { "StatusID" });
            DropIndex("dbo.Order", new[] { "UserID" });
            DropIndex("dbo.OrderDetail", new[] { "CatergoryID" });
            DropIndex("dbo.OrderDetail", new[] { "FoodID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.FoodItem", new[] { "CatergoryID" });
            DropIndex("dbo.Catergory", new[] { "Catergory2_CatergoryID" });
            DropTable("dbo.Settings");
            DropTable("dbo.UserType");
            DropTable("dbo.User");
            DropTable("dbo.Status");
            DropTable("dbo.Parking");
            DropTable("dbo.Reservation");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.FoodItem");
            DropTable("dbo.Catergory");
        }
    }
}
