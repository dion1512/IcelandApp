# IcelandApp
Application for Iceland Foods technical test

## Project Objective
"We are a small convenience store with a prime location in a prominent city ran by a friendly
shopkeeper named Alison. We also buy and sell only the finest goods. Unfortunately, our goods are
constantly degrading in quality as they approach their sell by date. We currently update our
inventory manually."

Your task is to write a program which automates the inventory management based on the following rules:

**Rules**:
+ All items have a SellIn value which denotes the number of days we have to sell the item
+ All items have a Quality value which denotes how valuable the item is
+ At the end of each day our system lowers both values for every item
+ Once the sell by date has passed, Quality degrades twice as fast
+ The Quality of an item is never negative
+ The Quality of an item is never more than 50
+ "Aged Brie" increases in Quality the older it gets
+ “Frozen Item” decreases in Quality by 1
+ "Soap" never has to be sold or decreases in Quality
+ "Christmas Crackers", like “Aged Brie”, increases in Quality as its SellIn value approaches; Its
+  quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
+ but quality drops to 0 after Christmas
+ "Fresh Item" degrade in Quality twice as fast as “Frozen Item”

## Further Considerations
I have completed the task in a way that demonstrates C# and .NET ability. minimising the use of LINQ, databases and other external resources. If I had more time, I would have created a database to store these values. I would also create a continuous webjob which would encompass the code in the updateQuality method and run daily using a trigger. To improve performance, I would adapt the methods to run asynchronously, utilising tasks.

I have not handled the INVALID ITEM. Without a database of existing items to compare against, I would have instead checked against a list of known items (as per the test input), and if the input did not match these items, I would have returned the expected result of NO SUCH ITEM.

## Instructions
1. Clone the repository to Visual Studio
2. Launch the application locally
3. In Postman, create a POST request to the url https://localhost:<port>/api/readPost
4. Enter the Test Input in to the request body as a raw text input
5. Send
  
