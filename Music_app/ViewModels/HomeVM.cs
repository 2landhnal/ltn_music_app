﻿namespace Music_app.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<BaiHatVM> BaiHatVMs { get; set; }
        public IEnumerable<TacGiaVM> TacGiaVMs { get;set; }
        public IEnumerable<AlbumVM> AlbumVMs { get;set;}
    }
}
