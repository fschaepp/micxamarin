using System;
using System.Collections.Generic;
using MediaLib.App.Common.Model;

namespace MediaLib.App.Common.Interface
{
    public interface IMediaRepository
    {
        IEnumerable<Media> Get();

        Media Get(Guid id);

        void Update(Media media);

        void Delete(Media media);

        void Add(Media media);
    }
}
