namespace teahouse.Models {
    public class ServiceResponse<T> {
        public ServiceResponseEnum Message { get; set; }
        public T? Data { get; set; }
        
        public ServiceResponse(ServiceResponseEnum Message = ServiceResponseEnum.Success, T? Data = default) {
            this.Message = Message;
            this.Data = Data;
        }
    }
}