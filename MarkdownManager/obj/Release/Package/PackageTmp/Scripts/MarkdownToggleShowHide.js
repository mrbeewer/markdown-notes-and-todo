// Variables - Important Elements for Toggles
var elMarkdownInput = $('#markdown-input');
var elMarkdown = $('#markdown-view');

var elHtml = $('#html-view');
var elHtmlOutput = $('#html-output');

var elPartial = $('#todo-partial');
var elEasyTodo = $('#easy-todo');

var elJSFiddle = $('#jsfiddle');
var elFiddlePartial = $('#toggle');
var elFiddlePartialDemo = $('#toggleDemo');

// When the Markdown View Toggle is Changed
elMarkdown.change(function () {
    ViewAdjustByToggle(elMarkdown, elMarkdownInput, elHtmlOutput);
});

// When the HTML View Toggle is Changed
elHtml.change(function () {
    ViewAdjustByToggle(elHtml, elHtmlOutput, elMarkdownInput);
});   
        
// When the ToDo Toggle is Changed
elEasyTodo.change(function () {
    var status = elEasyTodo.prop("checked");
    // alert("clicked");
    // console.log(status);

    if (status) {
        // show the todo partial
        elPartial.css("display", "block");
    } else {
        // hide the todo partial
        elPartial.css("display", "none");
    }
});

// When the JSFiddle Toggle is Changed
elJSFiddle.change(function () {
    var status = elJSFiddle.prop("checked");
    // alert("clicked");
     console.log(status);

    if (status) {
        // show the JSFiddle partial
        //elFiddlePartial.css("display", "block");
         elFiddlePartial.toggle("slide");
    } else {
        // hide the JSFiddle partial
        // elFiddlePartial.css("display", "none");
        elFiddlePartial.toggle("slide");
    }
});

// When the JSFiddle Toggle (DEMO) is Changed
elJSFiddle.change(function () {
    var status = elJSFiddle.prop("checked");
    // alert("clicked");
    console.log(status);

    if (status) {
        // show the JSFiddle partial
        //elFiddlePartial.css("display", "block");
        elFiddlePartialDemo.toggle("slide");
    } else {
        // hide the JSFiddle partial
        // elFiddlePartial.css("display", "none");
        elFiddlePartialDemo.toggle("slide");
    }
});

// Depending on Toggle value, hide/show one element, change class for another
function ViewAdjustByToggle(elChanged, elToShowHide, elToShrinkExpand) {
    var status = elChanged.prop("checked");
    // alert("clicked");
    // console.log(status);

    if (status) {
        // show the markdown view, label, buttons
        elToShowHide.css("display", "block");
        // shrink the html view
        elToShrinkExpand.toggleClass("col-md-12", false);
        elToShrinkExpand.toggleClass("col-md-6", true);
    } else {
        // hide the markdown view, label, buttons
        elToShowHide.css("display", "none");
        // expand the html view
        elToShrinkExpand.toggleClass("col-md-6", false);
        elToShrinkExpand.toggleClass("col-md-12", true);
    }
};