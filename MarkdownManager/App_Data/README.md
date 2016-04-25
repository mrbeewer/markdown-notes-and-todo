# Markdown Manager
Markdown Manager is a web based markdown editor with a focus on management through notes and todos.
*Markdown Conversion Powered By [Jon Schlinkert - Remarkable](https://github.com/jonschlinkert/remarkable)*
*Syntax Highlighting Powered By [Highlight.js](https://highlightjs.org/)*

[Live Demo](http://markdownmanager.azurewebsites.net/)
Test with --> username: *fake@fake.com*, password: *P_assw0rd1*
Note: Some company networks will not allow the login process to function properly.
<p align="center">
  <img width="400px" src="/Images/Logo.png" alt="MarkdownManager Logo"/>
<p>


### Screenshots:
<p align="center">
  <img width="400px" src="/Images/UMLMarkdownManager.png" alt="Planning"/>
  <br>
  <img width="400px" src="/Images/MarkdownManager_EditNote.png" alt="MarkdownManager - Edit Note"/>
  <br>
  <img width="400px" src="/Images/MarkdownManager_JSFiddlePost.png"  alt="MarkdownManager - Post to JSFiddle"/>
</p>

### Technology:
* HTML, CSS, JavaScript, jQuery
* ASP.NET (C#) + Razor - MVC and RESTful API
* OAuth - User Authorization
* Microsoft SQL - Database Management
* Bootstrap - CSS Framework
* GIMP - Logo
* [Bootstrap Toggle](http://www.bootstraptoggle.com/)
* [GitHub Buttons by MDO](https://github.com/mdo/github-buttons)
* [Draw.io](http://draw.io) - Wireframes and ERD
* [Trello](https://trello.com) - SCRUM Board


### Links:
* Use Case Diagram, Activity Diagram, User Stories, Wireframes, ERD
  * [Image](https://github.com/mrbeewer/markdown-notes-and-todo/blob/master/misc-files/UML-Markdown+Todo.png)
  * [PDF](https://github.com/mrbeewer/markdown-notes-and-todo/blob/master/misc-files/UML-Markdown+Todo.pdf)
  * [Draw.io](https://drive.google.com/file/d/0B1PeprrWaiPLcEZVa0NiUTBEa1E/view?usp=sharing)
* [SCRUM Board](https://trello.com/b/rvAVYeyS)
* Live App - [Markdown Manager](http://markdownmanager.azurewebsites.net/)

### Approach:
  * Planning Phase
    * With more time available on this project, more time was spent on the planning phase.
    * Used Trello for basic SCRUM management as well as keeping track of resources and things that needed to be researched further.
    * Used Draw.io to put together Use Case Diagrams, UML Diagrams, User Stories, and Wireframing.
  * Project Outline
    * MVP - Web application where a user can login / register, use Markdown make documents (with code snippets) and create / manage a ToDo list.
    * After logging into the system, the user will be able to use Markdown syntax to make documents as they see fit. This project initially is 
	geared towards notes / project management for a programmer / developer. As such, code blocks and syntax highlighting is important.
    * In order to keep the user within the app and to facilitate task management, the user will be able to easily add and view ToDo tasks. 
	These tasks will also have an option for tagging for increased organization.
    * Planned Technologies:
      * ASP.NET for server side
      * SQL for database (unsure at the moment)
      * HTML / CSS / JavaScript for client side
      * *Will take advantage of available Markdown converters and syntax highlighting as the intention of this project is not to develope those 
	  from scratch but show the ability to incorporate previously developed technology.*
  * Development Phase
    * With ASP.NET / C# being a new environment and language for this project, three to four days were spend purely working through tutorials and 
	reading through digital resources to get up to speed.
    * With enough knowledge to be dangerous, I transitioned to getting a base app together to build from using these basics. As I continue to 
	enhance the app, more resources will be collected to answer the more specific questions that arise.
    * Before working together the models and controllers, focus was turned to defining a preliminary database structure to achieve the desired result.
    * ToDo Module: 
		* Due to simplicity and similarity to available tutorials / guides, the ToDo portion was tackled first. Configuring the relational 
		piece of the tables proved to difficult, with out-dated tutorials and inconsistent information. Once the ToDo items were tied to their user, some 
		bonus features such as pagination, filtering, sorting were added.
	* Notes Module: 
		* Creating the Notes Module was largely an exercise in replicating the CRUD of ToDo and adding the Markdown Conversion functionality. 
		Although the Markdown conversion works well, it took time to fully integrate and adjust overlapping CSS for an appropriate appearance. 
		Another learned lesson on this portion was dealing with data validation. As the converter will allow HTML tags, the validation routine was catching 
		the tags and reporting unsafe conditions (and potential of allowing hack-scripts). In this case, the tags are desired and after a lot of investigation, 
		adding `[AllowHtml]` to the Document Model provided correct validation. Although there are methods to counter the validation through the controller, 
		that could introduce security holes into the application.
	* As I always focus on functionality programming, little has been done on the overall look of the page. Thankfully the default project with Visual 
	Studio uses Bootstrap and a minimal appearance that I can build from.
	* JSFiddle Form: 
		* Although not quite as 'cool' as an embedded sandbox, a form (opened through more toggle switches!) can be accessed allowing the user 
		to enter HTML/CSS/JS and open a JSFiddle with the code ready. The idea is that a user could copy code from their notes and get a JSFiddle ready without
		switching between pages multiple times. The user can also place the link for the JSFiddle along the code block for later viewing / testing / editing.
		* A couple of pieces needed to be tackled for the form that were new. The first was having the form slide in with a z-index 'above' the page. Although 
		the form could have been implemented like the 'easy add' ToDo, I didn't want to push the containers farther down and require the user to scroll up/down 
		to copy the code from their notes and paste them into the form.
		* The next piece was successfully posting the information to JSFiddle. The original attempt of using an AJAX call was unsuccessful (potentially a header 
		issue? Needs further investigation) however, the documentation included an example that used the form post method which worked appropriately.
	* With (theoretically) the last toggle added to the markdown header, focused switched to styling and responsive management. Although this application's deployment
	has been focused for desktop use, it could still be efficiently used on a tablet sized device. As such, the Bootstrap grid system was used to keep input boxes 
	and toggles from stacking up. Working with multiple CSS files has shown me that projects may require a stronger focus on consolidation.
	* While working with CSS and JSFiddle, some time was spent creating a sample logo using GIMP.
	* Modal Support:
		* With the success of implementing partials and testing the application during class, it was noticed that there were some annoying routing when creating and 
		editing a note. With original routing, one would navigate to the 'Notes', click 'New Note' which would bring the user to a create page housing the markdown 
		containers. However, if the user would then 'save' the note, they would be redirected back to the note list view. Similar routing occured when editting the 
		document. These redirects are annoying if the user just wanted to save their work. As such, a modal to display text boxes for the new note name and parent 
		folder and then redirect the user to the edit view was implemented. Within the edit view, instead of redirecting to the list view, a 'saved' message is returned 
		and the user is able to continue working on their note.
		* A Html.BeginForm helper for deletion was also added as directing the user to a delete view seemed unnecessary.
  * Final Thoughts
    * As this project was developed, it soon became an exercise in integrating and implementing snippets, widgets, etc that have been previously developed. Due to the 
	timeframe, this was certainly necessary, but it is also beneficial to learn to incorporate work that has been performed rather than always starting from scratch. As 
	a person that loves solving problems, this is of interest because problems become more interesting with more moving parts. However, it is hard to feel that one has 
	*done* much when *just* putting parts together. At that point, I remind myself that car manufacturers are combining the work of external suppliers to make that car.
	* Learning and using ASP.NET (C#) for this project over the course of two weeks was a challenge, especially with the not always helpful resources (largely due to being 
	out of date). My previous familiarity with  VB / VB.NET was certainly a benefit regarding the learning curve.
	* Things I would have done differently: Now that I better understand the built-in authentication and session management, I would structure the Models a little differently. 
	As they currently exist, the 'MyUser' model which was intended to store user preferences is unused and not needed. With a better understanding of using partials, I also 
	believe I could improve the efficiency and streamline navigation and routing better.

### Installation:
**Install on your local system**
* *Git* the files
  * Fork the repository and `git clone` to your local system
* Setting up the Environment
  * This project was developed in VS 2015 (Community) using the LocalDB for local development.
  * While developing this project, it was learned that LocalDB is not always installed with VS 2015. Be sure to install any database updates!
* Open the Solution file in VS
  * Build the solution and make sure all the dependencies are loaded properly
* Check it out
  * Debug > Start without Debugging and VS will open in your default browser. As the database will be created, it may take a few seconds to load up.


### Unsolved Problems:
* **Embedded Code Sandbox** - During the planning and design stage, a user story was connected to the ability to run
/ test code while within the application. As there are a number of these sandboxes on the web, it was thought that
one should allow for embedding (and still allow editing / testing). In terms of a free source that could be integrated
within the timeline, nothing was found to fit the need. As such, the ability to put code from notes into a form to post
to JSFiddle was added. This is not the best solution, but may prove to be handy.
* Connected to the above, was unable to make a standard AJAX call to post the code to JSFiddle, may require additional 
specifiers. However, an [example](http://jsfiddle.net/zalun/sthmj/embedded/result/) was found using a form post to send
the information. This method works just as well.
* Would like to replace the 'confirm' alerts with something prettier than the browser defaults.




### Change Log:
  * 25APR2016
	* Added a note to the login page regarding company network interference. Have not yet been able to properly debug this.
  * 28JAN2016
	* Added a modal to manage note creation / editing more smoothly
	* @Html.BeginForm helper used for deletion instead of redirecting to a 'delete' view
	* 'Details' route/view is not currently being used, it currently is unnecessary
	* Code cleaning, commenting
	* Readme updates
  * 26JAN2016
	* CRUD funtionality has been working successfully
	* Added toggle button to post code to JSFiddle (to test/run)
	* Improved responsive design, specifically the toggle buttons as the screen width decreases.
  * 24JAN2016
	* Updated ToDo module - added ability to filter, search, and display with multiple pages
	* Added Notes module - able to CRUD notes, markdown conversion is functional, filter, search, pagination
  * 23JAN2016
    * Added TODO Model/Controller/CRUD
    * Time spent learning how to update database on 'checkbox' click rather than a submit button
  * 21JAN2016
    * Added initial ASP.NET (C#) base code
    * Readme updates (added Azure link)
  * 17JAN2016
    * Readme updates (links, typos)
    * Updated planning images (need a better name for that collection)
  * 16JAN2016
    * Repository Created
    * Added Links (Draw.io planning, Trello board) to README
