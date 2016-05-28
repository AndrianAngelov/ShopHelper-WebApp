$(function () {
    //            var isPostBack;
    //            if (isPostBack) {
    //                alert("Some");
    //            }
    var menu_ul = $('div.mainMenuWrapper ul li a.level2.static'),
         menu_a = $('div.mainMenuWrapper ul li a.level1.static'),
         item1 = $('div.mainMenuWrapper ul li a.level1.static.item1'),
         item2 = $('div.mainMenuWrapper ul li a.level1.static.item2'),
         item1Sumitems = $('div.mainMenuWrapper ul li a.level2.static.item1SubItem'),
         item2Sumitems = $('div.mainMenuWrapper ul li a.level2.static.item2SubItem');

    $('div.mainMenuWrapper ul.level1.static').addClass("menu1");

    if (counter == 0) {
        menu_ul.hide();
    }
    else {
        //alert(counter);
    }

    var c = 0;
    var listItems = $("div.mainMenuWrapper ul li a.level1.static");

    listItems.each(function (idx, a) {
        c++;
        var product = $(a);
        product.addClass('item' + c);
        // and the rest of your code
    });

    item1 = $("div.mainMenuWrapper ul li a.level1.item1");
    item2 = $("div.mainMenuWrapper ul li a.level1.item2");

    var str;
    var listItemsSubItems = $("div.mainMenuWrapper ul li a.static");

    listItemsSubItems.each(function (idx, a) {
        var product = $(a);

        if (product.hasClass('item1')) {
            str = "item1SubItems";
            //alert(str);
        }
        if (product.hasClass('item2')) {
            str = "item2SubItems";
            //alert(str);
        }
        if (product.hasClass("level2")) {
            product.addClass(str);
        }
    });
    var listItems1SubItems = $("div.mainMenuWrapper ul li a.item1SubItems");
    var listItems2SubItems = $("div.mainMenuWrapper ul li a.item2SubItems");

    item1.click(function (e) {
        e.preventDefault();
        listItems1SubItems.show("slow");
        listItems2SubItems.hide("slow");
    });
    item2.click(function (e) {
        e.preventDefault();
        listItems2SubItems.show("slow");
        listItems1SubItems.hide("slow");
        //                listItems2SubItems.next().stop(true, true).slideDown('normal');
    });

    //            menu_a.click(function (e) {
    //                e.preventDefault();

    //                if (!$(this).hasClass('active')) {
    //                    menu_a.removeClass('active');
    //                    menu_ul.filter(':visible').slideUp('normal');
    //                    $(this).addClass('active').next().stop(true, true).slideDown('normal');
    //                }
    //                else {
    //                    $(this).removeClass('active');
    //                    $(this).next().stop(true, true).slideUp('normal');
    //                }
    //                if ($(this).hasClass('active')) {
    //                    menu_ul.show();
    //                    menu_ul.filter(':visible').slideDown('normal');
    //                }
    //            });
});