Notes:

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



+++++++++++++++++++++



Interview Questions / Examples - Career


## Interview Questions / Examples

#### Interviewing as a developer ... AKA ... *How not to suck at interviewing*
 * Learn how to break problems down
 * Understand how to communicate
 * Common interview questions
 * Research company, understand the stack.
 * Don't be negative, don't belittle your work or say that you didn't / don't know what you were doing.

<br>

#### Breaking a problem down
 * Provided a problem
 * You need to solve it
 * Interviewers want to see how you think! (**Be verbal, but be professional!**)
 * Step by Step Breakdown
 * They want to see how you think, research, etc.
 * Be prepared to draw, whiteboard, take notes, act as if you are yourself.

<br>

#### Example 1 - Cat Rehabilitation Center - <3 Kitteh!
 * $10 / day (in care - medicine, food, lodging)
 * Free roaming cage - $200/each
   * sleeps 10 cats
   * 4ft x 4ft
 * Maximus Cage - $800/each (cats are more likely to be adopted)
   * sleeps 10 cats
   * 16ft x 16ft
 * Facility
   * 4800ft x 4800ft
   * Every cage must have 100ft between each

 * Gotcha's
   * How tall are the cages, what is the vertical element of this building?
   * Cost effective? / Outcome of cats?

<br>

#### Question 1 - Project you are most proud of?
 * Mention things you are excited about
 * Challenges on the project
 * Things you would do differently

#### Question 2 - If you had to pick front-end, back-end, or full-stack, which would you pick?
 * Preferred languages / databases / framework
 * Question pertaining to that topic (curve-ball)

#### Question 3 - What do you want to learn next?

#### Question 4 - Describe cross-domain origin error, how to fix it?

#### Question 5 - Experience in testing prototypes (mobile, apps, MVP)

#### Question 6 - Explain MVC

#### Question 7 - Referring to a project/code, why did you do something the way you did? (Ex: SPA - Backbone)
 * `backbonejs.org/#Router` -> the # is a 'hash-bang'

#### Common Interview Questions



<br>

#### Practice?
 * [TopCoder](https://www.topcoder.com/)
 * Algorithms






 +++++++++++++++++++++++++++++++++++++++


