#include "pch.h"
#include "ListNode.h"

ListNode* createLinkedList(const std::vector<int>& values) {
	if (values.empty()) return nullptr;
	ListNode* head = new ListNode(values[0]);
	ListNode* current = head;
	for (size_t i = 1; i < values.size(); ++i) {
		current->next = new ListNode(values[i]);
		current = current->next;
	}
	return head;
}

std::vector<int> linkedListToVector(ListNode* head) {
	std::vector<int> result;
	while (head) {
		result.push_back(head->val);
		head = head->next;
	}
	return result;
}

void deleteLinkedList(ListNode* head) {
	while (head) {
		ListNode* temp = head;
		head = head->next;
		delete temp;
	}
}

ListNode* reverseList(ListNode* head) {
	ListNode* current = head;
	ListNode* previous = nullptr;

	while (current) {
		ListNode* temp = current->next;
		current->next = previous;
		previous = current;
		current = temp;
	}
	return previous;
}

ListNode* deleteMiddle(ListNode* head) {
	ListNode* slow = head, * fast = head;
	if (!head->next) return nullptr;

	while (fast && fast->next) {
		fast = fast->next->next;
		if (!fast || !fast->next)
		{
			slow->next = slow->next->next;
			break;
		}
		slow = slow->next;
	}
	return head;
}

ListNode* oddEvenList(ListNode* head) {
	if (!head || !head->next) return head;

	ListNode* oddPtr = head;
	ListNode* evenPtr = head->next;
	ListNode* evenHead = head->next;
	while (evenPtr && evenPtr->next) {
		oddPtr->next = oddPtr->next->next;
		oddPtr = oddPtr->next;

		evenPtr->next = evenPtr->next->next;
		evenPtr = evenPtr->next;
	}
	oddPtr->next = evenHead;
	return head;
}

bool hasCycle(ListNode* head) {
	if (!head || !head->next) return false;

	ListNode* slow = head;
	ListNode* fast = head;

	while (fast && fast->next) {
		slow = slow->next;
		fast = fast->next->next;
		if (slow == fast)
			return true;
	}
	return false;
}

void reorderList(ListNode* head) {
	if (!head || !head->next) return;

	ListNode* slow = head;
	ListNode* fast = head;

	while (fast && fast->next) {
		slow = slow->next;
		fast = fast->next->next;
	}
	ListNode* secondHalfHead = slow->next;
	slow->next = nullptr;

	secondHalfHead = reverseList(secondHalfHead);
	ListNode* current = head;
	while (current && secondHalfHead) {
		ListNode* temp = current->next;
		ListNode* secondHalfTemp = secondHalfHead->next;
		current->next = secondHalfHead;
		secondHalfHead->next = temp;
		current = temp;
		secondHalfHead = secondHalfTemp;
	}
}

ListNode* removeNthFromEnd(ListNode* head, int n) {
	ListNode* beforeHead = new ListNode(0, head);
	ListNode* left = beforeHead;
	ListNode* right = head;
	int index = 0;
	while (right != nullptr) {
		if (index >= n) {
			left = left->next;
		}
		right = right->next;
		index++;
	}
	ListNode* temp = left->next;
	left->next = left->next->next;
	ListNode* newHead = beforeHead->next;
	delete(temp);
	delete(beforeHead);
	return newHead;
}

// https://leetcode.com/problems/copy-list-with-random-pointer
//Node* copyRandomList(Node* head) {
//	if (!head)
//		return nullptr;
//
//	Node* cursor = head;
//	while (cursor) {
//		Node* temp = cursor->next;
//		Node* copy = new Node(cursor->val);
//		copy->next = temp;
//		cursor->next = copy;
//		cursor = temp;
//	}
//
//	cursor = head;
//	while (cursor) {
//		if (cursor->random) {
//			cursor->next->random = cursor->random->next;
//		}
//		else {
//			cursor->next->random = nullptr;
//		}
//		cursor = cursor->next->next;
//	}
//	cursor = head;
//	Node* deepCopyCursor = head->next;
//	Node* deepCopyHead = head->next;
//
//	while (deepCopyCursor->next) {
//		cursor->next = deepCopyCursor->next;
//		cursor = cursor->next;
//		deepCopyCursor->next = cursor->next;
//		deepCopyCursor = deepCopyCursor->next;
//	}
//	deepCopyCursor->next = nullptr;
//	cursor->next = nullptr;
//
//	return deepCopyHead;
//}

ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) {
	ListNode* temp = new ListNode(0);
	ListNode* current = temp;
	int carry = 0;
	while (l1 || l2 || carry > 0) {
		int val1 = 0;
		int val2 = 0;
		if (l1)
			val1 = l1->val;
		if (l2)
			val2 = l2->val;
		int total = val1 + val2 + carry;
		carry = total / 10;
		total %= 10;

		ListNode* newNode = new ListNode(total);
		current->next = newNode;
		current = current->next;

		if (l1)
			l1 = l1->next;
		if (l2)
			l2 = l2->next;
	}
	ListNode* result = temp->next;
	delete temp;
	return result;
}

int findDuplicate(std::vector<int>& nums) {
	int slow = nums[0];
	int fast = nums[0];

	do {
		slow = nums[slow];
		fast = nums[nums[fast]];
	} while (fast != slow);

	fast = nums[0];

	while (slow != fast) {
		slow = nums[slow];
		fast = nums[fast];
	}

	return slow;
}