const button = document.getElementById("searchBtn");
const input = document.getElementById("movieTitle");
const result = document.getElementById("result");

button.addEventListener("click", searchMovie);

async function searchMovie() {
    const title = input.value.trim();

    if (!title) {
        result.innerHTML = `<p class="error">Введіть назву фільму</p>`;
        return;
    }

    result.innerHTML = "🔍 Пошук...";

    try {
        const response = await fetch(`/api/movie?title=${encodeURIComponent(title)}`);

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(errorText);
        }

        const movie = await response.json();
        renderMovie(movie);
    }
    catch (error) {
        result.innerHTML = `<p class="error">${error.message}</p>`;
    }
}

function renderMovie(movie) {
    result.innerHTML = `
        <div class="movie-card">
            <img src="${movie.poster !== "N/A" ? movie.poster : ""}" alt="Poster">
            <div class="movie-info">
                <h2>${movie.title} (${movie.year})</h2>
                <p><span>Рейтинг:</span> ${movie.imdbRating}</p>
                <p><span>Тривалість:</span> ${movie.runtime}</p>
                <p><span>Режисер:</span> ${movie.director}</p>
                <p><span>Актори:</span> ${movie.actors}</p>
                <p>${movie.plot}</p>
            </div>
        </div>
    `;
}
