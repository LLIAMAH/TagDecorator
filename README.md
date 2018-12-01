# TagDecorator
Allow to use cascade Tag string creation base on TagBuilder class (.NET).

For some purpose it is required to create html tags by code and this procedure has few issues (IMHO). 
Common procedure of the creation suppose to create TagBuilder instance and step-by-step changing it's parameters. 
New solution: 
1. Write tag string name
2. Use .ToTag() extension
3. Continue use extensions to apply CSS classes and common attributes to tag.
4. At the end just call .ToString() to get raw html string or .ToHtmlString() to get System.Wb.Mvc.MvcHtmlString string instance

# Benefits
1. Less code - approx on 1/3 after refactoring
2. Simple to read.

# Examples
**Required result**  
Button: https://getbootstrap.com/docs/4.0/components/buttons/  
```html
<button type="button" class="btn btn-success">Success</button>
```
Old implementation:
```C#
var tb = new TagBuilder("button");
tb.Attributes.Add("type", "button");
tb.AddCssClass("btn");
tb.AddCssClass("btn-success");
tb.SetInnerText("Success");
var htmlString = tb.ToString(TagRenderMode.Normal);
```
New implementation:
```C#
var htmlString = "button".ToTag()
                    .AddAttribute("type", "button")
                    .AddCss(new[] {"btn", "btn-success"})
                    .SetText("Success")
                    .ToString();
```
  
**Required result**  
Card: https://getbootstrap.com/docs/4.0/components/card/  
```html
 <div class="card" style="width: 18rem;">
   <img class="card-img-top" src="..." alt="Card image cap">
   <div class="card-body">
     <h5 class="card-title">Card title</h5>
     <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
     <a href="#" class="btn btn-primary">Go somewhere</a>
   </div>
 </div>
```
Old implementation:
```C#
var divMain = new TagBuilder("div");
divMain.AddCssClass("card");
divMain.Attributes.Add("style", "width: 18rem;");

var img = new TagBuilder("img");
img.AddCssClass("card-img-top");
img.Attributes.Add("src", "...");
img.Attributes.Add("alt", "Card image cap");

var divBody = new TagBuilder("div");
divBody.AddCssClass("card-body");

var h = new TagBuilder("h5");
h.AddCssClass("card-title");
h.SetInnerText("Card title");

var p = new TagBuilder("p");
p.AddCssClass("card-text");
p.SetInnerText("Some quick example text to build on the card title and make up the bulk of the card's content.");

var a = new TagBuilder("a");
a.Attributes.Add("href", "#");
a.AddCssClass("btn");
a.AddCssClass("btn-primary");
a.SetInnerText("Go somewhere");

divBody.InnerHtml += h.ToString(TagRenderMode.Normal);
divBody.InnerHtml += p.ToString(TagRenderMode.Normal);
divBody.InnerHtml += a.ToString(TagRenderMode.Normal);

divMain.InnerHtml += img.ToString(TagRenderMode.Normal);
divMain.InnerHtml += divBody.ToString(TagRenderMode.Normal);

return divMain.ToString(TagRenderMode.Normal);
```
New implementation:
```C#
var htmlString = "div".ToTag()
    .AddCss("card")
    .AddAttribute("style", "width: 18rem;")
    .InnerHtml(new []
    {
        "img".ToTag()
            .AddCss("card-img-top")
            .AddAttributes(new[] {new[] {"src", "..."}, new[] {"alt", "Card image cap"}}),
        "div".ToTag()
            .AddCss("card-body")
            .InnerHtml(new []
            {
                "h5".ToTag().AddCss("card-title").SetText("Card title"),
                "p".ToTag().AddCss("card-text").SetText("Some quick example text to build on the card title and make up the bulk of the card's content."),
                "a".ToTag().AddCss(new[] {"btn", "btn-primary"}).AddAttribute("href", "#").SetText("Go somewhere")
            })
    }).ToString();
```
