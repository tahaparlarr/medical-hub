if (document.querySelector('#splide1')) {
    var splide = new Splide('#splide1', {
        type: 'loop',
        perPage: 2,
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

    splide.mount();
}

if (document.querySelector('#splide2')) {
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
}

document.querySelectorAll(".service-block").forEach(block => {
    const btn = block.querySelector(".toggle-btn");
    const link = block.querySelector(".learn-more");
    const text = block.querySelector(".toggle-text");

    const toggle = () => {
        btn.classList.toggle("active");
        text.classList.toggle("show");
    };

    btn.addEventListener("click", toggle);
    link.addEventListener("click", (e) => {
        e.preventDefault();
        toggle();
    });
});