using MassTransit;
using MqDtos;
using OTPService.Data;
using OTPService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Consumers
{
    public class NewCustomerConsumer : IConsumer<NewCustomerMqDto>
    {
        private readonly IOTPRepositoy _otpRepository;
        public NewCustomerConsumer(IOTPRepositoy otpRepository)
        {
            _otpRepository = otpRepository;
        }

        public Task Consume(ConsumeContext<NewCustomerMqDto> context)
        {
            PhoneNumberOTP dataToAdd = new PhoneNumberOTP();
            dataToAdd.Phone = context.Message.PhoneNumber;
            if (!_otpRepository.SaveOTP(dataToAdd).Result)
            {
              //send error message
            }

            return Task.CompletedTask;
        }
    }
}
