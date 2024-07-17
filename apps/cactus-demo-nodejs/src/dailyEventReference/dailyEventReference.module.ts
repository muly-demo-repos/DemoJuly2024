import { Module } from "@nestjs/common";
import { DailyEventReferenceModuleBase } from "./base/dailyEventReference.module.base";
import { DailyEventReferenceService } from "./dailyEventReference.service";
import { DailyEventReferenceController } from "./dailyEventReference.controller";

@Module({
  imports: [DailyEventReferenceModuleBase],
  controllers: [DailyEventReferenceController],
  providers: [DailyEventReferenceService],
  exports: [DailyEventReferenceService],
})
export class DailyEventReferenceModule {}
