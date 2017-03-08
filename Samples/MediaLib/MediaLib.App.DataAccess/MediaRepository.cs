using System;
using System.Collections.Generic;
using System.Linq;
using MediaLib.App.Common.Extensions;
using MediaLib.App.Common.Interface;
using MediaLib.App.Common.Model;

namespace MediaLib.App.DataAccess
{
    public class MediaRepository : IMediaRepository
    {
        private List<Media> medias = new List<Media>
            {
                new Media {Id = Guid.NewGuid(), Title = "Der Herr der Ringe - Die Gefährten"},
                new Media {Id = Guid.NewGuid(), Title = "Der Herr der Ringe - Die zwei Türme"},
                new Media {Id = Guid.NewGuid(), Title = "Der Herr der Ringe - Die Rückkehr des Königs"},
            };

        public IEnumerable<Media> Get()
        {
            return medias.ToList();
        }

        public Media Get(Guid id)
        {
            return medias.SingleOrDefault(m => m.Id == id);
        }

        public void Update(Media media)
        {
            var copy = new List<Media>(medias);
            copy.RemoveSingle(m => m.Id == media.Id);
            copy.Add(media);
            medias = copy;
        }

        public void Delete(Media media)
        {
            var copy = new List<Media>(medias);
            copy.Remove(media);
            medias = copy;
        }

        public void Add(Media media)
        {
            medias.Add(media);
        }
    }
}
