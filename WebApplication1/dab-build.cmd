@echo off
@echo This cmd file creates a Data API Builder configuration based on the chosen database objects.
@echo To run the cmd, create an .env file with the following contents:
@echo dab-connection-string=your connection string
@echo ** Make sure to exclude the .env file from source control **
@echo **
dotnet tool install -g Microsoft.DataApiBuilder
dab init -c dab-config.json --database-type mssql --connection-string "@env('dab-connection-string')" --host-mode Development
@echo Adding tables
dab add "Author" --source "[dbo].[authors]" --fields.include "au_id,au_lname,au_fname,phone,address,city,state,zip,contract" --permissions "anonymous:*" 
dab add "Employee" --source "[dbo].[employee]" --fields.include "emp_id,fname,minit,lname,job_id,job_lvl,pub_id,hire_date" --permissions "anonymous:*" 
dab add "Job" --source "[dbo].[jobs]" --fields.include "job_id,job_desc,min_lvl,max_lvl" --permissions "anonymous:*" 
dab add "PubInfo" --source "[dbo].[pub_info]" --fields.include "pub_id,logo,pr_info" --permissions "anonymous:*" 
dab add "Publisher" --source "[dbo].[publishers]" --fields.include "pub_id,pub_name,city,state,country" --permissions "anonymous:*" 
dab add "Sale" --source "[dbo].[sales]" --fields.include "stor_id,ord_num,ord_date,qty,payterms,title_id" --permissions "anonymous:*" 
dab add "Store" --source "[dbo].[stores]" --fields.include "stor_id,stor_name,stor_address,city,state,zip" --permissions "anonymous:*" 
dab add "Titleauthor" --source "[dbo].[titleauthor]" --fields.include "au_id,title_id,au_ord,royaltyper" --permissions "anonymous:*" 
dab add "Title" --source "[dbo].[titles]" --fields.include "title_id,title,type,pub_id,price,advance,royalty,ytd_sales,notes,pubdate" --permissions "anonymous:*" 
@echo Adding views and tables without primary key
@echo No primary key found for table/view 'discounts', using first Id column (stor_id) as key field
dab add "Discount" --source "[dbo].[discounts]" --fields.include "discounttype,stor_id,lowqty,highqty,discount" --source.type "view" --source.key-fields "stor_id" --permissions "anonymous:*" 
@echo No primary key found for table/view 'roysched', using first Id column (title_id) as key field
dab add "Roysched" --source "[dbo].[roysched]" --fields.include "title_id,lorange,hirange,royalty" --source.type "view" --source.key-fields "title_id" --permissions "anonymous:*" 
@echo Adding relationships
dab update Discount --relationship Store --target.entity Store --cardinality one
dab update Store --relationship Discount --target.entity Discount --cardinality many
dab update Employee --relationship Job --target.entity Job --cardinality one
dab update Job --relationship Employee --target.entity Employee --cardinality many
dab update Employee --relationship Publisher --target.entity Publisher --cardinality one
dab update Publisher --relationship Employee --target.entity Employee --cardinality many
dab update PubInfo --relationship Publisher --target.entity Publisher --cardinality one
dab update Publisher --relationship PubInfo --target.entity PubInfo --cardinality many
dab update Roysched --relationship Title --target.entity Title --cardinality one
dab update Title --relationship Roysched --target.entity Roysched --cardinality many
dab update Sale --relationship Store --target.entity Store --cardinality one
dab update Store --relationship Sale --target.entity Sale --cardinality many
dab update Sale --relationship Title --target.entity Title --cardinality one
dab update Title --relationship Sale --target.entity Sale --cardinality many
dab update Titleauthor --relationship Author --target.entity Author --cardinality one
dab update Author --relationship Titleauthor --target.entity Titleauthor --cardinality many
dab update Titleauthor --relationship Title --target.entity Title --cardinality one
dab update Title --relationship Titleauthor --target.entity Titleauthor --cardinality many
dab update Title --relationship Publisher --target.entity Publisher --cardinality one
dab update Publisher --relationship Title --target.entity Title --cardinality many
@echo Adding stored procedures
dab add "Byroyalty" --source "[dbo].[byroyalty]" --source.type "stored-procedure" --permissions "anonymous:execute" --rest.methods "get" --graphql.operation "query" 
dab add "Reptq1" --source "[dbo].[reptq1]" --source.type "stored-procedure" --permissions "anonymous:execute" --rest.methods "get" --graphql.operation "query" 
dab add "Reptq2" --source "[dbo].[reptq2]" --source.type "stored-procedure" --permissions "anonymous:execute" --rest.methods "get" --graphql.operation "query" 
dab add "Reptq3" --source "[dbo].[reptq3]" --source.type "stored-procedure" --permissions "anonymous:execute" --rest.methods "get" --graphql.operation "query" 
@echo **
@echo ** run 'dab validate' to validate your configuration **
@echo ** run 'dab start' to start the development API host **
