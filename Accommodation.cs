using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning3
{
    internal class Accommodation
    {
        private int roomId;
        private int hostId;
        private string roomType;
        private string borough;
        private string neighbourhood;
        private int reviews;
        private double overallSatisfaction;
        private int accomodates;
        private int bedrooms;
        private int price;
        private int minstay;
        private double latitude;
        private double longitude;
        private string lastModified;

        public Accommodation( int roomIdAcc, int hostIdAcc, string roomTypeAcc, string boroughAcc, string neighbourhoodAcc, int reviewsAcc, 
            double overallSatisfactionAcc, int accomodatesAcc, int bedroomsAcc, int priceAcc, int minstayAcc, double latitudeAcc, 
            double longitudeAcc, string lastModifiedAcc)
        {
            roomId = roomIdAcc;
            hostId = hostIdAcc;
            roomType = roomTypeAcc;
            borough = boroughAcc;
            neighbourhood = neighbourhoodAcc;
            reviews = reviewsAcc;
            overallSatisfaction = overallSatisfactionAcc;
            accomodates = accomodatesAcc;
            bedrooms = bedroomsAcc;
            price = priceAcc;
            minstay = minstayAcc;
            latitude = latitudeAcc;
            longitude = longitudeAcc;
            lastModified = lastModifiedAcc;

        }

        public int RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }


        public int HostId
        {
            get { return hostId; }
            set { hostId = value; }
        }


        public string RoomType
        {
            get { return roomType; }
            set { roomType = value; }
        }


        public string Borough
        {
            get { return borough; }
            set { borough = value; }
        }


        public string Neighbourhood
        {
            get { return neighbourhood; }
            set { neighbourhood = value; }
        }


        public int Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }

        public double OverallSatisfaction
        {
            get { return overallSatisfaction; }
            set { overallSatisfaction = value; }
        }

        public int Accomodates
        {
            get { return accomodates; }
            set { accomodates = value; }
        }

        public int Bedrooms
        {
            get { return bedrooms; }
            set { bedrooms = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Minstay
        {
            get { return minstay; }
            set { minstay = value; }
        }

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public string LastModified
        {
            get { return lastModified; }
            set { lastModified = value; }
        }
    }

}