#include "pch.h"
#include "Questions.h"
#include <unordered_set>
#include <stack>

bool canVisitAllRooms(std::vector<std::vector<int>>& rooms) {
	std::unordered_set<int> visited;
	std::stack<int> roomsToVisit;
	roomsToVisit.push(0);

	while (!roomsToVisit.empty()) {
		int currentRoom = roomsToVisit.top();
		roomsToVisit.pop();

		if (visited.count(currentRoom)) continue;
		visited.insert(currentRoom);
		for (int key : rooms[currentRoom]) {
			if (!visited.count(key)) {
				roomsToVisit.push(key);
			}
		}
	}
	
	return visited.size() == rooms.size();
}
