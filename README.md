# OData Test
[Documentation](https://learn.microsoft.com/en-us/odata/webapi-8/overview)

## Get All Customers
GET `/customers`

## Get Customer by ID
GET `/customers/{id}`

## Select Properties from Customer
GET `/customers?$select=Name`

GET `/customers/1?$select=Name`

## Filter Customers by Name
GET `/customers?$filter=Name eq 'Value'`

## Get Customer Orders
GET `/customers?expand=Orders`

## Order By
GET `/customers?$orderby=Name desc`

# Pagination
GET `/customers?$top=1&$skip=1`