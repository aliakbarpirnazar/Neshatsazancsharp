const hamburgerIcon = document.querySelector('.hamburger-icon');
const hamburgerMenu = document.querySelector('.hamburger-menu');
const crossIcon = document.querySelector('.cross-icon');
const showMorearticle = document.querySelector('#show-more-article');
const showMoremenu = document.querySelector('#show-more-menu');
const showMorelang = document.querySelector('#show-more-lang');

hamburgerIcon.addEventListener('click', function () {
  console.log(hamburgerMenu.style.transform);
  hamburgerMenu.classList.add('show-hamburger-menu');
});

crossIcon.addEventListener('click', function () {
  hamburgerMenu.classList.remove('show-hamburger-menu');
});

showMorearticle.addEventListener('mouseenter', function (e) {
  const ul = e.target.childNodes[5];
  ul.style.animation = 'showUp 0.35s 1';
  ul.style.display = 'block';
});

showMorearticle.addEventListener('mouseleave', function (e) {
  const ul = e.target.childNodes[5];
  ul.style.display = 'none';
});

showMoremenu.addEventListener('mouseenter', function (e) {
  const ul = e.target.childNodes[5];
  ul.style.animation = 'showUp 0.35s 1';
  ul.style.display = 'block';
});

showMoremenu.addEventListener('mouseleave', function (e) {
  const ul = e.target.childNodes[5];
  ul.style.display = 'none';
});

showMorelang.addEventListener('mouseenter', function (e) {
  const ul = e.target.childNodes[5];
  ul.style.animation = 'showUp 0.35s 1';
  ul.style.display = 'block';
});

showMorelang.addEventListener('mouseleave', function (e) {
  const ul = e.target.childNodes[5];
  ul.style.display = 'none';
});

