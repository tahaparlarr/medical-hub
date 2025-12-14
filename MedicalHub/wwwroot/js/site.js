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

// File Drop Zone
const dropZone = document.getElementById('dropZone');
const fileInput = document.getElementById('fileInput');
const dropContent = document.getElementById('dropContent');

dropZone.onclick = () => fileInput.click();

fileInput.onchange = () => {
    if (fileInput.files[0]) showPreview(fileInput.files[0].name);
};

dropZone.ondragover = (e) => { e.preventDefault(); dropZone.classList.add('drag-over'); };
dropZone.ondragleave = () => dropZone.classList.remove('drag-over');

dropZone.ondrop = (e) => {
    e.preventDefault();
    dropZone.classList.remove('drag-over');

    if (e.dataTransfer.files[0]) {
        fileInput.files = e.dataTransfer.files;
        showPreview(e.dataTransfer.files[0].name);
    }
};

const showPreview = (fileName) => {
    dropContent.innerHTML = `
        <i class="bi bi-check-circle-fill text-success fs-1"></i>
        <div class="mt-2 fs-6">${fileName}</div>
        <div class="text-secondary small mt-1">Yüklemeye hazır</div>
    `;
};