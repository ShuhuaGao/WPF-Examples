﻿Note that `SelectedPerson` can notify its changes. Thus, dependency properties of various controls can be bound to this `SelectedPerson` or its sub-properties. The interesting part is that the sub-properties do not need to support change notification.