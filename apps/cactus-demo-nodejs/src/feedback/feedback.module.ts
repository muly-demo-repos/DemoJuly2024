import { Module } from "@nestjs/common";
import { FeedbackModuleBase } from "./base/feedback.module.base";
import { FeedbackService } from "./feedback.service";
import { FeedbackController } from "./feedback.controller";

@Module({
  imports: [FeedbackModuleBase],
  controllers: [FeedbackController],
  providers: [FeedbackService],
  exports: [FeedbackService],
})
export class FeedbackModule {}
