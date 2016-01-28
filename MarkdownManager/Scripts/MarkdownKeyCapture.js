
window.onload = function () {
    var pad = document.getElementById('markdown-text');

    // make the tab act like a tab
    pad.addEventListener('keydown', function (e) {

        if (e.keyCode === 9) { // tab was pressed
            // get caret position/selection
            var start = this.selectionStart;
            var end = this.selectionEnd;

            var target = e.target;
            var value = target.value;

            // set textarea value to: text before caret + tab + text after caret
            target.value = value.substring(0, start)
                            + "\t"
                            + value.substring(end);

            // put caret at right position again (add one for the tab)
            this.selectionStart = this.selectionEnd = start + 1;

            // prevent the focus lose
            e.preventDefault();
        };

        if (e.keyCode === 66 && e.ctrlKey) { // CTRL + B
            // get caret position/selection
            var start = this.selectionStart;
            var end = this.selectionEnd;

            var target = e.target;
            var value = target.value;

            console.log(value.substring(0, start));
            console.log(value.substring(start, end));
            console.log(value.substring(end));

            // set textarea value to: text before caret + tab + text after caret
            target.value = value.substring(0, start) + "**"
                            + value.substring(start, end) + "**"
                            + value.substring(end);
            console.log("target.value:" + target.value);
            // put caret at right position again (add one for the tab)
            this.selectionStart = this.selectionEnd = start + 1;

            // prevent the focus lose
            e.preventDefault();
        };
    });

}