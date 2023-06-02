namespace CoreLogic.Business {
    [System.Serializable]
    struct Upgrade {
        
        public bool isBuyed;
        public int businessId;
        
        [System.NonSerialized]
        public float bust;
        
        [System.NonSerialized]
        public int price;
    }
}