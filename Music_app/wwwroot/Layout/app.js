



document.addEventListener("DOMContentLoaded", function () {
    var songItems = document.querySelectorAll(".songItem");
    songItems.forEach(function (songItem) {
        songItem.addEventListener("click", function () {
            var songId = this.querySelector(".playListPlay").id;
            var songName = this.querySelector("h5").innerText;
            var artistName = this.querySelector(".subtitle").innerText;
            var imageUrl = this.querySelector("img").src;
            var songLink = this.dataset.linknhac;

            console.log("ID: " + songId);
            console.log("Song Name: " + songName);
            console.log("Artist: " + artistName);
            console.log("Image URL: " + imageUrl);
            console.log("Link nha: " + songLink);

            songItems.forEach(function (item) {
                item.classList.remove("selected");
            });

            this.classList.add("selected");

            let link = 0;
            let poster_master_play = document.getElementById('poster_master_play');
          
            Array.from(document.getElementsByClassName('playListPlay')).forEach((element) => {
                element.addEventListener('click', (e) => {
                    link = e.target.dataset.linknhac;
                    var imgElement = e.target.closest('.songItem').querySelector("img");
                    imageUrl = imgElement.src;
                    var h5Element = e.target.closest('.songItem').querySelector("h5");
                    var subtitleElement = e.target.closest('.songItem').querySelector(".subtitle");
                    var songName = h5Element.innerText;
                    var artistName = subtitleElement.innerText;
                    var songId = e.target.id; // Lấy ID bài hát từ phần tử được nhấp
                    console.log(songName);
                    console.log(artistName);

                    makeAllPlays();
                    e.target.classList.remove('bi-play-circle-fill');
                    e.target.classList.add('bi-pause-circle-fill');
                    music.src = `../Source/BaiHat/${link}`;
                    poster_master_play.src = imageUrl;
                    poster_master_play.setAttribute("data-song-id", songId);
                    song_and_artist.innerHTML = `
                        <h5>${songName}<br><div class="subtitle">${artistName}</div></h5>
                    `;
                    music.play();

                    masterPlay.classList.remove('bi-play-fill');
                    masterPlay.classList.add('bi-pause-fill');
                    wave.classList.add('active2');
                    music.addEventListener('ended', () => {
                        masterPlay.classList.add('bi-play-fill');
                        masterPlay.classList.remove('bi-pause-fill');
                        wave.classList.remove('active2')
                    });

                    // Gửi yêu cầu lưu lịch sử nghe nhạc
                    console.log('Playing song:', songId);

                    // Gửi yêu cầu lưu lịch sử nghe nhạc
                    fetch('/api/History/SaveHistory', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify({
                            
                            IdbaiHat: songId
                        })
                    }).then(response => {
                        if (response.ok) {
                            console.log('Lịch sử nghe nhạc đã được lưu.');
                        } else {
                            console.log('Có lỗi xảy ra khi lưu lịch sử nghe nhạc.');
                        }
                    }).catch(error => {
                        console.log('Có lỗi xảy ra khi gửi yêu cầu:', error);
                    });
                });
            });
        });
    });
});
const music = new Audio("../Source/BaiHat/1.mp3");
let masterPlay = document.getElementById('masterPlay');
let wave = document.getElementsByClassName('wave')[0];
masterPlay.addEventListener('click',()=>{
    if (music.paused || music.currentTime <= 0) {
        music.play();
        masterPlay.classList.remove('bi-play-fill');
        masterPlay.classList.add('bi-pause-fill');
        wave.classList.add('active2');
    } else {
        music.pause();
        masterPlay.classList.add('bi-play-fill');
        masterPlay.classList.remove('bi-pause-fill');
        wave.classList.remove('active2')
    }
})

const makeAllPlays = () => {
    Array.from(document.getElementsByClassName('playListPlay')).forEach((element) => {           
            element.classList.add('bi-play-circle-fill');
            element.classList.remove('bi-pause-circle-fill');      
    })
}

const makeAllBackgrounds = () => {
    Array.from(document.getElementsByClassName('songItem')).forEach((element) => {
        element.style.background ="rgb(105, 105, 170, 0)";
    })
}

// Điều chỉnh thanh tiến trình và thời gian
const seek = document.getElementById('seek');
const currentStart = document.getElementById('currentStart');
const currentEnd = document.getElementById('currentEnd');
let bar2 = document.getElementById('bar2');
let dot = document.getElementsByClassName('dot')[0];
function formatTime(seconds) {
    const mins = Math.floor(seconds / 60);
    const secs = Math.floor(seconds % 60);
    return `${mins}:${secs < 10 ? '0' : ''}${secs}`;
}

music.addEventListener('timeupdate', ()=>{
    let music_curr = music.currentTime;
    let music_dur = music.duration;

   
    currentStart.innerHTML = formatTime(music_curr);
    currentEnd.innerHTML = formatTime(music_dur);

    let progressbar = parseInt((music.currentTime / music.duration) * 100);
    seek.value = progressbar;
    let seekbar = seek.value;
    bar2.style.width = `${seekbar}%`;
    dot.style.left = `${seekbar}%`;
});

seek.addEventListener('change', ()=>{
    music.currentTime = (seek.value / 100) * music.duration;
});

let vol_icon = document.getElementById('vol_icon');
let vol = document.getElementById('vol');
let vol_dot = document.getElementById('vol_dot');
let vol_bar = document.getElementsByClassName('vol_bar')[0];

vol.addEventListener('change', () => {
    if (vol.value == 0) {
        vol_icon.classList.remove('bi-volume-down-fill');
        vol_icon.classList.add('bi-volume-muter-fill');
        vol_icon.classList.remove('bi-volume-up-fill');
    }
    if (vol.value > 0) {
        vol_icon.classList.add('bi-volume-down-fill');
        vol_icon.classList.remove('bi-volume-muter-fill');
        vol_icon.classList.remove('bi-volume-up-fill');
    }
    if (vol.value > 50) {
        vol_icon.classList.remove('bi-volume-down-fill');
        vol_icon.classList.remove('bi-volume-muter-fill');
        vol_icon.classList.add('bi-volume-up-fill');
    }
    let vol_a = vol.value;
    vol_bar.style.width = `${vol_a}%`;
    vol_dot.style.left = `${vol_a}%`;
    music.volume = vol_a / 100;
})


document.addEventListener("DOMContentLoaded", function () {
    var recommended = document.getElementById("recommended");
    if (recommended) {
        recommended.addEventListener("click", function () {
            // Chuyển hướng đến action Index của controller DsgoiY
            window.location.href = '/DsgoiY/Index';
        });
    }
})


document.addEventListener("DOMContentLoaded", function () {
    var lastlistening = document.getElementById("lastlistening");
    if (lastlistening) {
        lastlistening.addEventListener("click", function () {
            // Chuyển hướng đến action Index của controller DsgoiY
            window.location.href = '/XemHistory/Index';
        });
    }
})
//Thêm sự kiện sử lý cho các trang chi tiết
document.addEventListener("DOMContentLoaded", function () {
    var playButtons = document.querySelectorAll(".play-button");

    playButtons.forEach(function (button) {
        button.addEventListener("click", function () {
            var songUrl = this.getAttribute("data-song-url");
            var songId = this.getAttribute("data-song-id");
            var songName = this.getAttribute("data-song-name");
            var artistName = this.getAttribute("data-artist-name");
            var imageUrl = this.getAttribute("data-image-url");

          


            music.src = songUrl;
            music.play();

            var poster_master_play = document.getElementById('poster_master_play');
            var song_and_artist = document.getElementById('song_and_artist');
            var masterPlay = document.getElementById('masterPlay');
            var wave = document.querySelector('.wave');
            poster_master_play.setAttribute("data-song-id", songId);
            song_and_artist.setAttribute("data-song-id", songId);

            poster_master_play.src = imageUrl;
            song_and_artist.innerHTML = `
                    <h5>${songName}<br><div class="subtitle">${artistName}</div></h5>
                `;

            masterPlay.classList.remove('bi-play-fill');
            masterPlay.classList.add('bi-pause-fill');
            wave.classList.add('active2');

            music.addEventListener('ended', () => {
                masterPlay.classList.add('bi-play-fill');
                masterPlay.classList.remove('bi-pause-fill');
                wave.classList.remove('active2');
            });

            // Gửi yêu cầu lưu lịch sử nghe nhạc
            fetch('/api/History/SaveHistory', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    IdbaiHat: songId
                })
            }).then(response => {
                if (response.ok) {
                    console.log('Lịch sử nghe nhạc đã được lưu.');
                } else {
                    console.log('Có lỗi xảy ra khi lưu lịch sử nghe nhạc.');
                }
            }).catch(error => {
                console.log('Có lỗi xảy ra khi gửi yêu cầu:', error);
            });
        });
    });
    // Sự kiện cho nút like
    var likeButton = document.getElementById('like');
    likeButton.addEventListener('click', function () {
        var songId = document.getElementById("poster_master_play").getAttribute("data-song-id");
        if (songId) {
            // Gửi yêu cầu lưu cảm xúc
            fetch('/api/Emotion/SaveEmotion', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    IdbaiHat: songId,
                    CamXuc1: 'like'
                })
            }).then(response => {
                if (response.status === 401) {
                    // Chuyển hướng đến trang đăng nhập
                    window.location.href = '/DangNhap/Index';
                } else if (response.ok) {
                    console.log('Emotion saved successfully.');
                    // Cập nhật giao diện nút like
                    likeButton.classList.toggle("selected");
                    dislikeButton.classList.remove("selected");
                } else {
                    console.log('Error saving emotion.');
                }
            }).catch(error => {
                console.log('Request error:', error);
            });
        }
    });

    // Sự kiện cho nút dislike
    var dislikeButton = document.getElementById('dislike');
    dislikeButton.addEventListener('click', function () {
        var songId = document.getElementById("poster_master_play").getAttribute("data-song-id");
        if (songId) {
            // Gửi yêu cầu lưu cảm xúc
            fetch('/api/Emotion/SaveEmotion', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    IdbaiHat: songId,
                    CamXuc1: 'dislike'
                })
            }).then(response => {
                if (response.status === 401) {
                    // Chuyển hướng đến trang đăng nhập
                    window.location.href = '/DangNhap/Index';
                } else if (response.ok) {
                    console.log('Emotion saved successfully.');
                    // Cập nhật giao diện nút dislike
                    dislikeButton.classList.toggle("selected");
                    likeButton.classList.remove("selected");
                } else {
                    console.log('Error saving emotion.');
                }
            }).catch(error => {
                console.log('Request error:', error);
            });
        }
    });
});