# Contact Information

CRUD operation for Contact information of user. Use Database first approach for loading realtion between table and database. Handle test cases with all controller API.

## Getting Started

Check below details to run the Contact information page.

### Prerequisites

You need to install SQL SERVER Express Edition to your machine.
"ContactInfo_script.sql" script find on "App_Data" directory on project. Execute "ContactInfo_script.sql" script on SQL SERVER 2015 + IDE.


Folder Structure:

```
ContactInfoProject
	-App_Data
	-App_Start
	-Content
	-Controllers
	-fonts
	-Models
		-ContactModel.edmx
		-ContactRepository.cs
		-IContactRepository.cs
	-Script
	-View
		-Contact
		-Shared
```

### Installing

A step to follow to run code on development env

Click on "ContactInfoProject.sln" solution.

```
ContactInfoProject.sln
```

project loaded with updated details.



## Running the tests

Following Test cases are available on "ContactInfoProject.Tests" project.
How to run the test cases.

```
1. On IDE -> click on "Test" menu
2. On sub-menu "Run" -> select "All Tests"
3. All test cases will run and give you the result.
```

## Deployment

For deployment of this project. 

```
Publish the project using file system. Deployed on IIS7. 
```

## Authors

* **Nitin Kurle** - *Initial work* 

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
