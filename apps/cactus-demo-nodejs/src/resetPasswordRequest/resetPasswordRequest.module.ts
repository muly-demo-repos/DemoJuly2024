import { Module } from "@nestjs/common";
import { ResetPasswordRequestModuleBase } from "./base/resetPasswordRequest.module.base";
import { ResetPasswordRequestService } from "./resetPasswordRequest.service";
import { ResetPasswordRequestController } from "./resetPasswordRequest.controller";

@Module({
  imports: [ResetPasswordRequestModuleBase],
  controllers: [ResetPasswordRequestController],
  providers: [ResetPasswordRequestService],
  exports: [ResetPasswordRequestService],
})
export class ResetPasswordRequestModule {}
