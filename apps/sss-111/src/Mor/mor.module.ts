import { Module } from "@nestjs/common";
import { MorService } from "./mor.service";
import { MorController } from "./mor.controller";
import { MorResolver } from "./mor.resolver";

@Module({
  controllers: [MorController],
  providers: [MorService, MorResolver],
  exports: [MorService],
})
export class MorModule {}
