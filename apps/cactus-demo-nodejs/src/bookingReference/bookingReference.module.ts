import { Module } from "@nestjs/common";
import { BookingReferenceModuleBase } from "./base/bookingReference.module.base";
import { BookingReferenceService } from "./bookingReference.service";
import { BookingReferenceController } from "./bookingReference.controller";

@Module({
  imports: [BookingReferenceModuleBase],
  controllers: [BookingReferenceController],
  providers: [BookingReferenceService],
  exports: [BookingReferenceService],
})
export class BookingReferenceModule {}
