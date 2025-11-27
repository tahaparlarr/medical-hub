var splide = new Splide('#splide1');
splide.mount();

var splide2 = new Splide('#splide2', {
    type: 'loop',
    perPage: 4.5,
    perMove: 1,
    focus: 0,
    gap: '1rem',
    arrows: false,
    pagination: false,
    autoplay: true,
    interval: 3000,
    pauseOnHover: true,
    omitEnd: false,

    breakpoints: {
        1024: { perPage: 2 },
        768: { perPage: 1 },
    },
});

splide2.mount();