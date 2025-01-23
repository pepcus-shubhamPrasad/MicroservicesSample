1. Create Table for Product Service 
		
		///

		CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing primary key
    ProductName NVARCHAR(255),              -- Allows nulls for nullable property
    ProductPrice DECIMAL(18, 2) NOT NULL,   -- Decimal with precision and scale
    IsDeleted BIT NOT NULL DEFAULT 0        -- Boolean field with default value
);

		///

2. Change Database name in Product Service APi in AppSetting.json file.
3. Run All Service ApiGatway/Authservice/Product/EshopingWeb.
4. Default userName for login Shubham