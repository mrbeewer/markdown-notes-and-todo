Angular Controllers - Class

## Angular Controllers
<p align="center"><img src="https://upload.wikimedia.org/wikipedia/commons/f/fc/AngularJS-large.png"></p>
<br>

#### 1\. Views

##### Angular owns the DOM

*   In our `/views/angular.ejs` file, we're going to specify which part of the DOM that Angular **owns**.
*   We're going to give it a **name** `<html ng-app="taskerApp">`
*   Angular **owns** this HTML element. That means that it can have full control to modify any DOM element inside of here. This is _extremely_ powerful.

#### Attaching an Angular controller

Angular allows us to bind a DOM element as a View directly to a controller. We're going to modify our container:
```
    <article ng-controller="TaskListCtrl">
      <div class="col-md-12">
      </div>
    </article>
```
We're going to tell our controller to render a list of our tasks:
```
    <article ng-controller="TaskListCtrl">
      <div class="col-md-12">
      <ul>
        <li ng-repeat="task in tasks">
          <span>{{task.name}}</span>
          <p>{{task.description}}</p>
          <p>{{'Completed: ' + task.completed}}
        </li>
      </ul>
      </div>
    </article>
```
Take a look at that view syntax. **What do you think is going to happen when Angular processes this Controller?**

Let's find out!

<br>
#### 2\. app.js

*   We need to create an app.js file
*   Let's do it here: `/public/javascripts/angular-app.js`
*   In your `angular.ejs` view, add a link to it:
*   `<script type='text/javascript' src="/javascripts/angular-app.js"></script>`
*   This should come after `angular.min.js`!
*   Inside of `angular-app.js`, we're going to create our application:

    // namespace: taskerApp
    var taskerApp = angular.module('taskerApp', []);

This **binds** our app to where we declared it in `<html ng-app="taskerApp">`.

Cool - now we need to bind that View we made to a controller.

<br>
#### 3\. Controllers

##### Inside **angular-app.js**...

*   We're going to create a controller. To demonstrate Angular's dynamic rendering, we're going to create a fake model to represent what we should see from our API...
```
    [{'name': 'Take out of the trash',
    'description': 'Don\'t forget the recyclables!',
    'completed': true },
    {'name': 'Reload ventra card',
    'description': 'Balance is low',
    'completed': false },
    {'name': 'Pick up surprise from UPS...',
    'description': 'its a secret to everyone',
    'completed': false }]
```
*   Now, let's create a controller:
```
    taskerApp.controller('TaskListCtrl', function ($scope) {
    });
```
*   Let's **scope** our sample data to the `<li ng-repeat="task in tasks">` in our view.
```
    taskerApp.controller('TaskListCtrl', function ($scope) {
      $scope.tasks = [
        {'name': 'Take out of the trash',
        'description': 'Don\'t forget the recyclables!',
        'completed': true },
        {'name': 'Reload ventra card',
        'description': 'Balance is low',
        'completed': false },
        {'name': 'Pick up surprise from UPS...',
        'description': 'its a secret to everyone',
        'completed': false },
      ];
    });
```
*   We're just giving `tasks` some objects.
*   This is also a for-in loop in our view.


<br>
#### OPEN YOUR VIEW

*   Seriously, go do it!
*   Here's a link!
*   [http://localhost:5000/angular](http://localhost:5000/angular)
*   DID YOU SEE THAT? Those TASKS were rendered in a list on our page!
*   This is MVC in action using Angular.
*   **How does this feel?**
<br>
<br>
