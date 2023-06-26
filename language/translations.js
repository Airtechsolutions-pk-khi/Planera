// Variables 
var lang = Cookies.get('lang'),
    //window.navigator.language, // Check the Browser language
translate; // Container of all translations

// Call translations json file and populate translate variable  
jQuery.getJSON("http://localhost:9090/language/translations.json", function (texts) {
    debugger
    translate=texts;

    // Translations Function: Get all the element with data-text
    jQuery("[data-translate]").each(function() {
        let text = jQuery(this).attr('data-translate'), // Save the Text into the variable
            numbers= text.match(/\d+/g),
            element = jQuery('[data-translate="'+text+'"]'),
            postHTML;

        if (numbers != null && numbers>1) 
                text= text.replace(numbers, '%n');
        
        if (translate[text]!==undefined) { // Check if exist the text in translation.json                      
            
            if (translate[text][lang]!==undefined) { // Check if exist the text in the browser language
                postHTML= translate[text][lang];
            } else { // If not exist the lang, show the text in primary Language (Recomend: English)
                postHTML= text;
            }

            if (numbers != null && numbers>1) 
                postHTML= postHTML.replace('%n', numbers);

            element.html(postHTML);

        } else {
            jQuery('[data-translate="'+text+'"]').html("ERR").css({'color':'red','font-weight':'bold'});
        }
    });
});

