# Product-Database

## Description
### This is a product database supporting products logistics within the international business. The current model is still in alpha phase and needs more development, but it works pretty well currently. It can add, search and view products which meets the initial requirements.

## Development
### This database is built using two different environment. First, the interface and the menu is built within Unity, using C# and several user interface effects. Secondly, the back-end database is developed using php language to query SQL commands and get data from MAMMP database. There are two different databases: the first database stores user login, in which the password is carefully hash to prevent personal information leak and the second databse store different product information. Especially, in order to store image in the databse, I have researched and found a way to convert images into Int64String on C# and put into the MAMMP database as a blob variable.

## Future innovation
### This database management will be developed later in the year. Some bugs related to changing and saving information will be fixed shortly within the next few weeks. 
### Potential development features would be efficient search (without the need for exact name, maybe using ID like in the store instead?) and transaction data will be stored into a text file so that it can printed out by the end of the week or month, just like in the bank system.
