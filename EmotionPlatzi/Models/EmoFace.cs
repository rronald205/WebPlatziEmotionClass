using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace EmotionPlatzi.Models
{
    public class EmoFace
    {
        public int Id { get; set; }
        public int EmoPictureId { get; set; }

        #region
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion

        //la sentencia virtual hace que esta propiedad no sea parte del modelo
        //y permite la navegacion bidireccional entre este modelo y EmoPicture
        public virtual EmoPicture 
            Picture { get; set; }
        public virtual ObservableCollection<EmoEmtion> 
            Emotions{ get; set; }

    }
}