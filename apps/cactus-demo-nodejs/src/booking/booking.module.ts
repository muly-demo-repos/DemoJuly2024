import { Module } from "@nestjs/common";
import { BookingModuleBase } from "./base/booking.module.base";
import { BookingService } from "./booking.service";
import { BookingController } from "./booking.controller";

@Module({
  imports: [BookingModuleBase],
  controllers: [BookingController],
  providers: [BookingService],
  exports: [BookingService],
})
export class BookingModule {}
