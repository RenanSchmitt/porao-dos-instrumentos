//the $(document).ready() function is down at the bottom

//Source: http://www.jqueryrain.com/?pcso3drF

//Examples:
//Default stars
//<div id="stars-default"><input type=hidden" name="rating"/></div>

//Green stars with a callback and a preset value
//<div id="stars-green" data-rating="3"></div>

//Ten hearts!
//<div id="stars-green" data-rating="3"></div>

 (function ( $ ) {
 
     $.fn.rating = function( method, options ) {
         method = method || 'create';
         // This is the easiest way to have default options.
         var settings = $.extend({
             // These are the defaults.
             limit: 5,
             value: 0,
             glyph: "glyphicon-star",
             coloroff: "gray",
             coloron: "gold",
             size: "2.0em",
             cursor: "default",
             onClick: function () {},
             endofarray: "idontmatter"
         }, options );
         var style = "";
         style = style + "font-size:" + settings.size + "; ";
         style = style + "color:" + settings.coloroff + "; ";
         style = style + "cursor:" + settings.cursor + "; ";
	

		
         if (method == 'create')
         {
             //this.html('');	//junk whatever was there
			
             //initialize the data-rating property
             this.each(function(){
                 attr = $(this).attr('data-rating');
                 if (attr === undefined || attr === false) { $(this).attr('data-rating',settings.value); }
             })
			
             //bolt in the glyphs
             for (var i = 0; i < settings.limit; i++)
             {
                 this.append('<span data-value="' + (i+1) + '" class="ratingicon glyphicon ' + settings.glyph + '" style="' + style + '" aria-hidden="true"></span>');
             }
			
             //paint
             this.each(function() { paint($(this)); });

         }
         if (method == 'set')
         {
             this.attr('data-rating',options);
             this.each(function() { paint($(this)); });
         }
         if (method == 'get')
         {
             return this.attr('data-rating');
         }

         //ENABLE OR DISABLE TO SET VALUE RATING
         //register the click events
         this.find("span.ratingicon").click(function() {
             rating = $(this).attr('data-value')
             $(this).parent().attr('data-rating',rating);
             paint($(this).parent());
             settings.onClick.call( $(this).parent() );
         })

         function paint(div)
         {
             rating = parseInt(div.attr('data-rating'));
             div.find("input").val(rating);	//if there is an input in the div lets set it's value
             div.find("span.ratingicon").each(function(){	//now paint the stars
				
                 var rating = parseInt($(this).parent().attr('data-rating'));
                 var value = parseInt($(this).attr('data-value'));
                 if (value > rating) { $(this).css('color',settings.coloroff); }
                 else { $(this).css('color',settings.coloron); }
             })
         }

     };
 
 }( jQuery ));

$(document).ready(function(){

    $(".stars-default").rating();
    $(".stars-green").rating('create',{coloron:'green',onClick:function(){ alert('rating is ' + this.attr('data-rating')); }});
    $(".stars-herats").rating('create',{coloron:'red',limit:10,glyph:'glyphicon-heart'});	
});
