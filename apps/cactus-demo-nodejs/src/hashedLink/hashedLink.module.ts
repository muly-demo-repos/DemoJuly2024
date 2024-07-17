import { Module } from "@nestjs/common";
import { HashedLinkModuleBase } from "./base/hashedLink.module.base";
import { HashedLinkService } from "./hashedLink.service";
import { HashedLinkController } from "./hashedLink.controller";

@Module({
  imports: [HashedLinkModuleBase],
  controllers: [HashedLinkController],
  providers: [HashedLinkService],
  exports: [HashedLinkService],
})
export class HashedLinkModule {}
