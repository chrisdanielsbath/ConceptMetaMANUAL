
function handleLoad() {
  var acc = document.getElementsByClassName("accordion");

  // for each button...
  for (i = 0; i < acc.length; i++)
  {
    // ...expand panel if appropriate...
    if (acc[i].classList.contains('active'))
    {
      var panel = acc[i].nextElementSibling;
      panel.style.maxHeight = panel.scrollHeight + "px";
    }
    
    // ...add add an event handler
    acc[i].addEventListener("click", function() {
      this.classList.toggle("active");
      var panel = this.nextElementSibling;
      if (panel.style.maxHeight)
      {
        panel.style.maxHeight = null;
      }
      else
      {
        panel.style.maxHeight = panel.scrollHeight + "px";
      }
    });
  }
}