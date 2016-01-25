# Markdown Notes & Todo
Web based markdown editor focused on note taking and tracking ToDo's

#### [Click Me! (SOON)](http://markdownmanager.azurewebsites.net/)
<br>
<br>


### Screenshots:
<p align="center">
  <img width="400px" src="https://github.com/mrbeewer/markdown-notes-and-todo/blob/master/misc-files/UML-Markdown+Todo.png" alt="Planning"/>
  <br>
  <!-- <img width="400px" src="https://github.com/Beelers-Blockers/moogl/blob/NoBackbone/screenshots/moogl-secondaryRefinementWChoices.png" alt="moogl - Secondary Refinement With Choices View"/>
  <br>
  <img width="400px" src="https://github.com/Beelers-Blockers/moogl/blob/NoBackbone/screenshots/moogl-mapWPins.png"  alt="moogl - Map With Pins / Locations View"/>
  <br>
  <img width="400px" src="https://github.com/Beelers-Blockers/moogl/blob/NoBackbone/screenshots/moogl-mapWDetails.png"  alt="moogl - Map With Location Detail (small) View"/>
  <br>
  <img width="400px" src="https://github.com/Beelers-Blockers/moogl/blob/NoBackbone/screenshots/moogl-LocationDetails.png"  alt="moogl - Location Detail View"/>
  <br>
  <img width="400px" src="https://github.com/Beelers-Blockers/moogl/blob/NoBackbone/screenshots/moogl-BurgerDetails.png"  alt="moogl - Burger Detail View"/> -->
</p>

### Technology:
<!-- * HTML, CSS, JavaScript, jQuery
* Node.js, Express.js - MVC and RESTful API
* MongoDB - Database Management
* MongoHub - Easy DB Modification
* Passport - User Authentication and Sessions
* JSON - API Dealing
* Semantic - CSS Framework
* [JSON Generator](http://www.json-generator.com/) - Database of fake restaurants -->
* [Draw.io](http://draw.io) - Wireframes and ERD
* [Trello](https://trello.com) - SCRUM Board
* [Bootstrap Toggle](http://www.bootstraptoggle.com/)

### Links:
* Use Case Diagram, Activity Diagram, User Stories, Wireframes, ERD
  * [Image](https://github.com/mrbeewer/markdown-notes-and-todo/blob/master/misc-files/UML-Markdown+Todo.png)
  * [PDF](https://github.com/mrbeewer/markdown-notes-and-todo/blob/master/misc-files/UML-Markdown+Todo.pdf)
  * [Draw.io](https://drive.google.com/file/d/0B1PeprrWaiPLcEZVa0NiUTBEa1E/view?usp=sharing)
* [SCRUM Board](https://trello.com/b/rvAVYeyS)
* Live App - [SOON](http://markdownmanager.azurewebsites.net/)

### Approach:
  * Planning Phase
    * With more time available on this project, more time was spent on the planning phase.
    * Used Trello for basic SCRUM management as well as keeping track of resources and things that needed to be researched further.
    * Used Draw.io to put together Use Case Diagrams, UML Diagrams, User Stories, and Wireframing.
  * Project Outline
    * MVP - Web application where a user can login / register, use Markdown make documents (with code snippets) and create / manage a ToDo list.
    * After logging into the system, the user will be able to use Markdown syntax to make documents as they see fit. This project initially is geared towards notes / project management for a programmer / developer. As such, code blocks and syntax highlighting is important.
    * In order to keep the user within the app and to facilitate task management, the user will be able to easily add and view ToDo tasks. These tasks will also have an option for tagging for increased organization.
    * Planned Technologies:
      * ASP.NET for server side
      * SQL for database (unsure at the moment)
      * HTML / CSS / JavaScript for client side
      * *Will take advantage of available Markdown converters and syntax highlighting as the intention of this project is not to develope those from scratch but show the ability to incorporate previously developed technology.*
  * Development Phase
    * With ASP.NET / C# being a new environment and language for this project, three to four days were spend purely working through tutorials and reading through digital resources to get up to speed.
    * With enough knowledge to be dangerous, I transitioned to getting a base app together to build from using these basics. As I continue to enhance the app, more resources will be collected to answer the more specific questions that arise.
    * Before working together the models and controllers, focus was turned to defining a preliminary database structure to achieve the desired result.
    * Due to simplicity and similarity to available tutorials / guides, the ToDo portion was tackled first. Configuring the relational piece of the tables proved to difficult, with out-dated tutorials and inconsistent information. Once the ToDo items were tied to their user, some bonus features such as pagination, filtering, sorting were added.


### Installation:
<!-- **Install on your local system**
* *Git* the files
  * Fork the repository and `git clone` to your local system
* Setting up the Database
  * Required: MongoDB (https://www.mongodb.org/)
  * HIGHLY Recommended: MongoHub (https://github.com/jeromelebel/MongoHub-Mac)
  * Within MongoHub:
    * Create `moogl` Database, `locations` Collection, `searches` Collection
    * Add data -> Double click on the collection (opens the query), click on Insert, and copy the contents of `db/seeds/LocationSeed.json` and `db/seeds/SearchSeed.json` appropriately
* Install
  * Within the root `moogl` folder, run `npm install` from the terminal. This will prepare/install the necessary dependencies for this project. If they are all successful, continue on...
  * Again from the root `moogl` folder, run `npm start` to start the server.
* Check it out
  * In your favorite browser, go to `localhost:3000` -->
<!--
**Install on Digital Ocean**
* Create Droplet
  * Set name of droplet ... `thoughtful`
  * Choose plan ... $5/month
  * Choose region ... America
  * Choose Distribution ... Ubuntu
  * Click CREATE
* Config that Server!
  * Once the email from Digital Ocean arrives, keep note of the IP address and password, you will need those in the next steps.
  * On the terminal, access the server by `ssh root@123.123.123.123` using the IP sent by Digital Ocean.
  * Answer yes to the authenticity alert
  * Enter the provided password (twice) and setup a new password
  Use the following commands
  ```
  sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv 7F0CEB10
  # Add the MongoDB team's key to the list of trusted keys

  echo 'deb http://downloads-distro.mongodb.org/repo/ubuntu-upstart dist 10gen' | sudo tee /etc/apt/sources.list.d/mongodb.list
  # Add reference to the repository to our `apt` configuration

  apt-get update
  # updates the list of software our server knows about

  apt-get install mongodb-org git build-essential openssl libssl-dev pkg-config
  # Install MongoDB packages, git, and dependencies (Y x1)

  git clone https://github.com/Beelers-Blockers/moogl.git
  # clone down the repo with the correct URL (use HTTPS)

  wget https://nodejs.org/dist/v4.2.4/node-v4.2.4.tar.gz
  # download Node.js source code

  tar xzvf node-v
  # extract the archive

  cd node-v*
  # move into the node director

  ./configure
  make
  # configure and build Node (takes while! ~30min?)

  make install
  # install Node

  rm -rf ~/node-v*
  # remove the source code and directory (clean it up!)

  cd moogl
  # change directory

  npm install
  # install dependencies

  mongoimport --db moogl --collection searches --type json --file ~/moogl/db/seeds/SearchSeed.json --jsonArray
  # Run in terminal, not mongo!!

  mongoimport --db moogl --collection locations --type json --file ~/moogl/db/seeds/LocationsSeed.json --jsonArray
  # Run in terminal

  npm start
  # run the server and test with IP.IP.IP.IP:3000

  npm install -g forever
  # install Forever globally

  cd moogl
  # move to the moogl folder if not there already

  forever start --minUptime 1000 --spinSleepTime 1000 ./bin/www
  # start the server and keep it running
  ``` -->


### Unsolved Problems:
* SOON




### Change Log:
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
