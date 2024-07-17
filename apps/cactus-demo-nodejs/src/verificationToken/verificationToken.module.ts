import { Module } from "@nestjs/common";
import { VerificationTokenModuleBase } from "./base/verificationToken.module.base";
import { VerificationTokenService } from "./verificationToken.service";
import { VerificationTokenController } from "./verificationToken.controller";

@Module({
  imports: [VerificationTokenModuleBase],
  controllers: [VerificationTokenController],
  providers: [VerificationTokenService],
  exports: [VerificationTokenService],
})
export class VerificationTokenModule {}
