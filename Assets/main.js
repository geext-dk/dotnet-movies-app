// imports
import './style.scss';

import $ from 'jquery';
import 'bootstrap';
import '@fortawesome/fontawesome-free/js/all.js';

// executes on ready
$(function () {
  // change default search form submitting to make an AJAX call
  $('#search-form').on('submit', function (e) {
    e.preventDefault();
    var search_string = $('#input-filter').val();
    var filter_opt = $('#filter-opts').val();
    var sort_opt = $('#sort-opt').val();
    $('#partial-dest').empty();
    $.get(`/api/films?searchString=${search_string}&criterion=${filter_opt}&sortOption=${sort_opt}`)
      .done(function (films) {
        const div = document.createElement('div');
        div.classList = ['row'];
        if (films.length == 0) {
          const pNotFound = document.createElement('p');
          pNotFound.innerHTML = "No films have been found";
          div.appendChild(pNotFound);
        } else {
          films.forEach(function (film) {
            const filmDiv = document.createElement('div');
            filmDiv.classList.add('col-6', 'col-sm-3', 'col-md-2', 'col-lg-2');

            const filmLink = document.createElement('a');
            filmLink.href = "/Info?id=" + film.id;

            const posterImg = document.createElement('img');
            posterImg.src = film.posterPath;
            posterImg.className = 'w-100';
            posterImg.alt = '';

            const filmTitle = document.createElement('h6');
            filmTitle.innerHTML = film.title;

            const filmInfo = document.createElement('p');
            filmInfo.className = 'film-type';
            filmInfo.innerHTML = `${film.genre} (${film.releaseYear})`;

            // construct HTML
            filmLink.appendChild(posterImg);
            filmLink.appendChild(filmTitle);

            filmDiv.appendChild(filmLink);
            filmDiv.appendChild(filmInfo);

            div.appendChild(filmDiv);
          });

          const partialDest = document.getElementById('partial-dest');
          partialDest.innerHTML = div.outerHTML;
        }
      });
  });

  // sort films on sort option changes
  $('#sort-opt').change(function () {
    $('#search-form').submit();
  });

  // show the form to add a review on click
  $(".btn-view").click(function () {
    $(".container.rev-add").toggle();
  });

  // submit the form in Index.cshtml
  $('#search-form').submit();
});

/*** Info.cshtml ***/
$(document).ready(function () {
});