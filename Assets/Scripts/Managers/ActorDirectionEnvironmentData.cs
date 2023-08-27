using System;
using System.Collections.Generic;

namespace Managers
{
    [Serializable]
    public  class ActorDirectionEnvironmentData
    {
        private Direction _direction;
        private List<TileInfoData> _tileInfoData;
        
        public Direction Direction
        {
            get { return _direction;}
            private set {}
        }
        public List<TileInfoData> TileInfoData
        {
            get { return _tileInfoData;}
            private set {}
        }

        public ActorDirectionEnvironmentData(Direction direction, List<TileInfoData> tileInfoData)
        {
            _direction = direction;
            _tileInfoData = tileInfoData;
        }

        public bool IsDirectionHasGivenTileType(TileType tileType)
        {
            for (int i = 0; i < _tileInfoData.Count; i++)
                if (_tileInfoData[i].TileType == tileType)
                    return true;

            return false;
        }
        
        public TileInfoData GetTileWithType(TileType tileType)
        {
            for (int i = 0; i < _tileInfoData.Count; i++)
                if (_tileInfoData[i].TileType == tileType)
                    return _tileInfoData[i];

            return null;
        }

    }
}