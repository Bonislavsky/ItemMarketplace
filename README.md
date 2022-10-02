# ItemMarketplace
test task


if you gonna use this project change connection string in appsettings.json
  "ConnectionStrings": {
    "MarketplaceConnection": "you`r string"
  }

*******************************

i use swagger for documentation.
swagger/index.html:
![image](https://user-images.githubusercontent.com/108452138/193470455-2588d01d-c514-4aae-99df-006cfea59422.png)

method: 
GET(/api/Auctions) - return List<sale>
POST(/api/Auctions) - create => return Sale
GET(/api/Auctions/{id}) - return Sale by Id
PUT(/api/Auctions/{id}) - change Sale by Id
DELETE(/api/Auctions/{id}) - Delete Sale by Id
GET(/api/Auctions/SortedSales/{salesNames}) - get sorted List<Sale> By Item.Name
