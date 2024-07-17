import { Module } from "@nestjs/common";
import { CredentialModuleBase } from "./base/credential.module.base";
import { CredentialService } from "./credential.service";
import { CredentialController } from "./credential.controller";

@Module({
  imports: [CredentialModuleBase],
  controllers: [CredentialController],
  providers: [CredentialService],
  exports: [CredentialService],
})
export class CredentialModule {}
