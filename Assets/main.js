// imports
import './style.scss';

import $ from 'jquery';
import 'bootstrap';

// executes on ready
$(function() {
  // change default search form submitting to make an AJAX call
  $('#search-form').submit(function(e) {
    e.preventDefault();
    var search_string = $('#input-filter').val();
    var filter_opt = $('#filter-opts').val();
    var sort_opt = $('#sort-opt').val();
    $('#partial-dest').load('/Home/PartialGet?searchString=' + search_string
                            + '&criterion=' + filter_opt
                            + '&sortOption=' + sort_opt);
  });

  // sort films on sort option changes
  $('#sort-opt').change(function() {
    $('#search-form').submit();
  });

  // show the form to add a review on click
  $(".btn-view").click(function(){
    $(".container.rev-add").toggle();
  });

  // submit the form in Index.cshtml
  $('#search-form').submit();
});

/*** Info.cshtml ***/
$(document).ready(function(){
});