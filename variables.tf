variable "runtime" {
  type        = string
  description = "lambda function runtime"
}

variable "batch_size" {
  type = number
  description = "Event source batch size"
}

variable "max_batch_window" {
  type = number
  description = "Event source max batch window in sec"
}

variable "log_retention_period" {
  type = number
  description = "CW log retention period for lambda function"
}

variable "tags" {
  type = map
  description = "tags defined for resources"
  default = {}
}
