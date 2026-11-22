const SKILLS_RULES = {
none: {
hasSkill: false,
trigger: "none",
durationSec: 0,
cooldownSec: 0,
effectText: "कोई स्किल सक्रिय नहीं है।"
},
passive: {
hasSkill: true,
trigger: "automatic",
durationSec: 0,
cooldownSec: 0,
effectText: "स्किल हमेशा ऑटोमैटिक रूप से काम करती है।"
},
active: {
hasSkill: true,
trigger: "button",
defaultDurationSec: 10,
defaultCooldownSec: 25,
effectText: "स्किल आइकॉन दबाने पर चालू होती है, समय पूरा होने पर कूलडाउन शुरू होता है, और कूलडाउन खत्म होने पर फिर तैयार हो जाती है।"
}
};

const CHARACTER_SKILL_RULES = {
adam: { type: "none" },
eve: { type: "none" },
alok: {
type: "active",
skillName: "Drop the Beat",
durationSec: 10,
cooldownSec: 25,
speedBoostPercent: 15,
healPerSec: 3
},
andrew: {
type: "passive",
skillName: "Armor Harden",
armorLossReductionPercent: 20
},
maxim: {
type: "passive",
skillName: "Gluttony Boost",
useSpeedBoostPercent: 25
}
};

function createActiveSkillController(rule) {
let state = "ready"; // "ready" | "active" | "cooldown"
let remainingSec = 0;

return {
getStatus() {
return { state, remainingSec };
},
pressSkillButton() {
if (rule.type !== "active") {
return { ok: false, reason: "यह एक्टिव बटन वाली स्किल नहीं है।" };
}
if (state !== "ready") {
return { ok: false, reason: अभी ${state} है (${remainingSec}s बाकी)। };
}
state = "active";
remainingSec = rule.durationSec || 10;
return { ok: true, state, durationSec: remainingSec };
},
tickOneSecond() {
if (state === "active") {
remainingSec -= 1;
if (remainingSec <= 0) {
state = "cooldown";
remainingSec = rule.cooldownSec || 25;
}
} else if (state === "cooldown") {
remainingSec -= 1;
if (remainingSec <= 0) {
state = "ready";
remainingSec = 0;
}
}
return { state, remainingSec };
}
};
}